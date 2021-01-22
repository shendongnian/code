    static void Main(string[] args)
            {
                int a=0, b = 0, c = 0;
                int n = Convert.ToInt16(Console.ReadLine());
                string[] arr_temp = Console.ReadLine().Split(' ');
                int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
                foreach (int i in arr)
                {
                    if (i > 0) a++;
                    else if (i < 0) b++;
                    else c++;
                }
                Console.WriteLine("{0}", (double)a / n);
                Console.WriteLine("{0}", (double)b / n);
                Console.WriteLine("{0}", (double)c / n);
                Console.ReadKey();
            }
