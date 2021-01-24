    namespace UnorderedArrayListNamespace
    {
        public class UnorderedArrayList
        {
            public int[] list;
            protected int next;
            // protected int Count;
    
            public UnorderedArrayList()
            {
                list = new int[100];
                next = 0;
            }
    
    
    
            public void insert(ref int item)
            {
                list[next] = item;
                next++;
            }
    
            public void remove(ref int item)
            {
                //find value, if it exists
                for (int i = 0; i < next; i++)
                {
                    if (item.Equals(list[i]))
                    {
                        list[i] = list[next - 1];  //Move last item to empty slot
                        next--;
                        break; //break because we only remove first
                    }
                }
    
            }
    
            public void removeAll(ref int item)
            {
                //find value, if it exists
                for (int i = 0; i < next; i++)
                {
                    if (item.Equals(list[i]))
                    {
                        list[i] = list[next - 1];  //Move last item to empty slot
                        next--;
                    }
                }
            }
    
            public int[] InsertionSort(ref int item)
            {
                //First we add the item
                insert(ref item);
    
                for (int i = 0; i < next - 2; i++)
                {
                    for (int j = next - 1; j > i; j--)
                    {
                        if (list[i] > list[j])
                        {
                            int temp = list[j];
                            list[j] = list[i];
                            list[i] = temp;
                        }
                    }
                }
                return list;
    
            }
    
            public int Min()
            {
                if (next == 0) throw new Exception("No element is list, cannot get minimum");
                return list[0];
            }
            public int Max()
            {
                if (next == 0) throw new Exception("No element is list, cannot get maximun");
                return list[next - 1];
            }
    
    
            
            public void print()
            {
                for (int i = 0; i < next; i++)
                {
                    Console.Write("{0} ", list[i]);
                }
                Console.WriteLine();
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                UnorderedArrayList u = new UnorderedArrayList();
    
                u.print();
                int var = 7;
                u.insert(ref var);
                var = 12;
                u.insert(ref var);
                var = 5;
                u.insert(ref var);
                var = 5;
                u.insert(ref var);
                var = 5;
                u.insert(ref var);
                var = 96;
                u.insert(ref var);
                u.print();
                var = 5;
                u.remove(ref var);
                u.print();
                u.InsertionSort(ref var);
                u.print();
            
            Console.WriteLine("Minimum of sortedlist is {0}", u.Min());
            Console.WriteLine("Maximum of sortedlist is {0}", u.Max());
            u.removeAll(ref var);
            u.print();
            Console.ReadKey();
            }
        }
    }
