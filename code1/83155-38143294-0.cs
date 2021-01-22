        public static int[] radixSort(int[] ar)
        {
            int width = 0;
            foreach (int el in ar)
            {
                int numDigits = el.ToString().Length;
                if (numDigits > width)
                    width = numDigits;
            }
            int md, n;
            Dictionary<int, LinkedList> queue = null;
            Action refreshQueue = () =>
           {
               queue = new Dictionary<int, LinkedList>();
               for (int i = 0; i <= 9; i++)
               {
                   queue[i] = null;
               }
           };
            refreshQueue();
            for (int i = 1; i <= width; i++)
            {
                md = (int)Math.Pow(10, i); 
                n = md / 10; 
                foreach (int el in ar)
                {
                    int ithPlace = (int)((el % md) / n);
                    if (queue[ithPlace] == null)
                        queue[ithPlace] = new LinkedList(new LinkedListNode(el));
                    else
                        queue[ithPlace].add(new LinkedListNode(el));
                }
                List<int> newArray = new List<int>();
                for (int k = 0; k <= 9; k++)
                {
                    if (queue[k] != null)
                    {
                        LinkedListNode head = queue[k].head;
                        while (head != null)
                        {
                            newArray.Add(head.value);
                            head = head.next;
                        }
                    }
                }
                ar = newArray.ToArray();
                refreshQueue();
            }
            return ar;
        }
