        class LinkedList
        {
            private Node Head { get; set; } = null;
    
            public void Insert(int d)
            {
                Console.WriteLine("Insert : " + d);
                var newNode = new Node() { Data = d, Next = null };
                if (Head == null)
                {
                    Head = newNode;
                }
                else
                {
                    newNode.Next = Head;
                    Head = newNode;
                }
            }
    
            public void Delete(int d)
            {
                Console.WriteLine("Delete : "+d);
                var node = Head;
                Node currNode = Head;
                Node prevNode = null;
                while (node != null)
                {
                    currNode = node;
                    if (node.Data == d)
                    {
                        if(prevNode != null)
                        {
                            prevNode.Next = currNode.Next;
                        }
                        else
                        {
                            Head = Head.Next;
                        }
                        break;
                    }
                    prevNode = currNode;
                    node = node.Next;
                }
            }
    
            public void Print()
            {
                var list = Head;
                Console.Write("Elements: ");
                while (list != null)
                {
                    Console.Write(list.Data + " ");
                    list = list.Next;
                }
                Console.WriteLine();
            }
        }
