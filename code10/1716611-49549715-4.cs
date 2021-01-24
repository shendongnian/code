    using System.IO;
    using System;
    
    class Program
    {
        static void Main()
        {
            int[] array = {1, 1, 6, 5, 4, 3, 4, 6, 1, 7, 2, 1, 4, 9};
            allDistinct(array);
        }
        
        static int[] allDistinct(int[] array)
        {
            Array.Sort(array);
            
            printArray(array); // first step monitoring
            
            int n = array.Length;
            
            // iterate through array
            for(int i=0;i<n-1;i++)
            {
                // bubble push duplicates to the back
                while(array[i] == array[i+1])
                {
                    for(int j=i+1;j<n-1;j++)
                    {
                        array[j] = array[j+1];
                    }
                    array[n-1] = array[i];
                    n--;
                }
                
                printArray(array); // loop steps monitoring
            }
            
            return array;
        }
        
        static void printArray(int[] array)
        {
            for(int i=0;i<array.Length;i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
