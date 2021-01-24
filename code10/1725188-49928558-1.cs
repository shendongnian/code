    using System;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void swap(string[] array, int first, int second)
            {
                var temp = array[first];
                array[first] = array[second];
                array[second] = temp;
            }
    
            static void quickSort(string[] array, int left, int right)
            {
                int i = left, j = right;
                var pivot = array[(left + right) / 2];
    
                while (i <= j)
                {
                    while (array[i].IsBigger(pivot))
                    {
                        i++;
                    }
    
                    while (array[j].IsBigger(pivot))
                    {
                        j--;
                    }
    
                    if (i <= j)
                    {
                        // Swap                    
                        swap(array, i, j);
    
                        i++;
                        j--;
                    }
                }
    
                // Recursive calls
                if (left < j)
                {
                    quickSort(array, left, j);
                }
    
                if (i < right)
                {
                    quickSort(array, i, right);
                }
            }
    
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
    
                var array = new[] { "31415926535897932384626433832795", "1", "3", "10", "3", "5" };
    
                // Print the unsorted array
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }
    
                Console.WriteLine();
    
                quickSort(array, 0, array.Length - 1);
    
                // Print the sorted array
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }
    
                Console.WriteLine();
                Console.WriteLine("Done!");
    
                Console.ReadLine();
            }
        }
    
        public static class StringExtension
        {
            public static bool IsBigger(this string a, string b)
            {
                if (a.Length < b.Length) return false;
                else if (a.Length > b.Length) return true;
    
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] > b[i]) return true;
    
                    return false;
                }
    
                return false;
            }
        }
    }
