    class Program
    {
        
        static void Main(string[] args)
        {
           // string linked List
            GenericsLinkedList<string> stringLinkedList = new GenericsLinkedList<string>(); //object 1
            string s1 = "Yes";
            string s2 = "No";
            string s3 = "True";
            string s4 = "False";
            stringLinkedList.AddHead(s1);
            stringLinkedList.AddHead(s2);
            stringLinkedList.AddHead(s3);
            stringLinkedList.AddHead(s4);
            //display List
            foreach (string str in stringLinkedList)
            {
                Console.WriteLine("----"+str);
            }
            //Integer LinkedList
            GenericsLinkedList<int> integerList = new GenericsLinkedList<int>();
            int n1 = 1;
            int n2 = 2;
            int n3 = 3;
            integerList.AddHead(n1);
            integerList.AddHead(n2);
            integerList.AddHead(n3);
            foreach (int Intger in integerList)
            {
                Console.WriteLine("----" + Intger);
            }
            Console.ReadKey();
        }
    }
    // Generic Linked List
    class GenericsLinkedList<T>
    {
        class LinkedlistNode
        {
            private LinkedlistNode next;
            private T item;
            public LinkedlistNode(T t)
            {
                next = null;
                item = t;
            }
            public LinkedlistNode Next
            {
                get
                {
                    return next;
                }
                set
                {
                    next = value;
                }
            }
            public T Item
            {
                get
                {
                    return item;
                }
                set
                {
                    item = value;
                }
            }       
        }
       private LinkedlistNode head;
       public GenericsLinkedList()
       {
           head = null;
       }
       public void AddHead(T t)
       {
           LinkedlistNode node = new LinkedlistNode(t);
           node.Next = head;
           head = node;
       }
       public IEnumerator<T> GetEnumerator()
       {
           LinkedlistNode current = head;
           while(current != null)
           {
               yield return current.Item;
               current = current.Next;
           }
       
       }
    }
