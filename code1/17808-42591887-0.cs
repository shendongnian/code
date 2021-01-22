    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace MostFrequentElement
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] array = new int[] { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3, 1, 1, 7, 7, 7, 7, 7 };
                Array.Sort(array, (a, b) => a.CompareTo(b));
                int counter = 1;
                int temp=0 ;
                
                List<int> LOCE = new List<int>();
                foreach (int i in array)
                {
                    counter = 1;
                    foreach (int j in array)
                    
    {
                        if (array[j] == array[i])
                        {
                            counter++;
                        }
                        else {
                        counter=1;
                        }
                        if (counter == temp)
                        {
                            LOCE.Add(array[i]);
                        }
                        if (counter > temp)
                        {
                            LOCE.Clear();
                            LOCE.Add(array[i]);
                            temp = counter;
    
                        }
                    }
    
                }
                foreach (var element in LOCE)
                {
                    Console.Write(element + ",");
                }
                Console.WriteLine();
                Console.WriteLine("(" + temp + " times)");
                Console.Read();
            }
        }
    }
