    static void Main(string[] args)
            {
                string[] array1 = Directory.GetFiles(@"D:\");
                string[] array2 = System.IO.Directory.GetDirectories(@"D:\");
                Console.WriteLine("--- Files: ---");
                foreach (string name in array1)
                {
                    Console.WriteLine(name);
                }
                foreach (string name in array2)
                {
                    Console.WriteLine(name);
                }
                      Console.ReadLine();
            }
