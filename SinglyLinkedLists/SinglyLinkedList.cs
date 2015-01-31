using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode firstNode;

        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }
       
        
        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
       public SinglyLinkedList(params object[] values)
       {
           foreach (object thing in values)
           {
               this.AddLast(thing.ToString());
           }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

       
             public void AddAfter(string existingValue, string value)
        {
            var current = firstNode;
            while (current != null)
            {
                if (current.Value == existingValue)
                {
                    var temporary = current.Next;
                    current.Next = new SinglyLinkedListNode(value);
                    current.Next.Next = temporary;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("Value not found");
        }

        public void AddFirst(string value)
        { 
            SinglyLinkedListNode first = firstNode;
            firstNode = new SinglyLinkedListNode(value);
            firstNode.Next = first;
        }
        public void AddAfterLastItem(string value)
        {
            SinglyLinkedListNode node = firstNode;
            if (node == null)
            {
                firstNode = new SinglyLinkedListNode(value);
            }
            else
            {

                node = node.Next;
                while (true)
                {
                    if (node.Next == null)
                    {
                        break;
                    }

                    node = node.Next;

                }
                node.Next = new SinglyLinkedListNode(value);
            }
        }
        
        public void AddLast(string value)
        {
            SinglyLinkedListNode node = firstNode;
            if (firstNode == null)
            {
                firstNode = new SinglyLinkedListNode(value);
            }
            else
            {

               
                while (true)
                {
                    if (node.Next == null)
                    {
                        break;
                    }

                    node = node.Next;

                }
                node.Next = new SinglyLinkedListNode(value);
            }
        }
        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            throw new NotImplementedException();
        }
        public string ElementAt(int index)
        {
            SinglyLinkedListNode node = firstNode;
            if (node == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }
                return node.Value;
            }
        }


        public override string ToString()
        {
            StringBuilder Empty = new StringBuilder();
            SinglyLinkedListNode node = firstNode;
            Empty.Append("{ ");
            if (node == null)
            {
                Empty.Append("}");
                return Empty.ToString();
            }
            while (!node.IsLast())
            {
                Empty.Append("\"" + node.Value + "\", ");
                node = node.Next;
            }
            Empty.Append("\"" + node.Value + "\" }");
            return Empty.ToString();

        }

        public string First()
        {
            if (firstNode == null)
            {
                return null;
            }
            else
            {
                return firstNode.Value;
            }
        }

        public int IndexOf(string value)
        {
            throw new NotImplementedException();
        }
        public bool IsSorted()
        {
            throw new NotImplementedException();
        }
        private SinglyLinkedListNode NodeAt(int index)
        {
            var result = firstNode;
            for (int i = 0; i < index; i++)
            {
                result = result.Next;
            }
            return result;
        }
        private void Swap(SinglyLinkedListNode previousPrevious, SinglyLinkedListNode prev, SinglyLinkedListNode curr)
        {
            var temp = prev;
            prev.Next = curr.Next;
            curr.Next = temp;
            if (firstNode == temp)
            {
                firstNode = curr;
            }
            else
            {
                previousPrevious.Next = curr;
            }
        }
        public void Sort()
        {
            if (firstNode == null || firstNode.Next == null)
            {
                return;
            }
            for (int i = 0; i < this.Count(); i++)
            {
                SinglyLinkedListNode lowest = NodeAt(i);
                
                for (int j = 0; j < this.Count(); j++)
                {
                    if (lowest > NodeAt(i))
                    {
                        lowest = NodeAt(j);

                    }
                    if (lowest != NodeAt(i))
                    {
                        Swap(NodeAt(-1), NodeAt(i), lowest);
                    }
                    
                }

            }
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            if (firstNode == null)
            {
                return null;
            }
            int counter = 0;
            SinglyLinkedListNode node = firstNode;
            while (node != null) 
            {
                if (node.Next == null)
                {
                    break;
                }
                node = node.Next;
                counter++;
            }
            return this.ElementAt(counter);
        }




       //ublic void ListRemoveFirstNode()
       // {
       //  p    SinglyLinkedList list = new SinglyLinkedList();
       //     SinglyLinkedListNode node = firstNode;
       //     var temp = node.Next;
       //     firstNode = temp;
       // }


        public void Remove(string value)
        {
            List<string> list = new List<string>();
            SinglyLinkedListNode node = firstNode;
            if (node == firstNode) 
            {

                list.Remove(firstNode.Value);
                
            }
           
        }

      

        public string[] ToArray()
        {
            List<string> willBeArray = new List<string>();
            SinglyLinkedListNode current = firstNode;
            while (current != null)
            {
                willBeArray.Add(current.Value);
                current = current.Next;
            }
            return willBeArray.ToArray();
        }
    }
}
            
          
          
        
    
