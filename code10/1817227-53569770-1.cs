    using System;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                String[] arr = new String[3];
                arr[0] = "B";
                arr[1] = "C";
                arr[2] = "A";
                Console.WriteLine(arr[0]);
                Console.WriteLine(arr[1]);
                Console.WriteLine(arr[2]);
                Sort(arr);
                Console.WriteLine(arr[0]);
                Console.WriteLine(arr[1]);
                Console.WriteLine(arr[2]);
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Test\Result.txt"))
                {
                    foreach (string str in arr)
                    {
                        file.WriteLine(str);
                    }
                }
                Console.ReadLine();
            }
            public static void Sort(String[] arr)
            {
                String temp = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i].CompareTo(arr[j]) > 0)
                        {
                            temp = arr[j];
                            arr[j] = arr[i];
                            arr[i] = temp;
                        }
                    }
                    //Console.WriteLine(arr[i]);
                }
            }
        }
    }
