     class Program
        {
            static void Main(string[] args)
            {
                string abc = "10abc";
                int result = 0;
                int.TryParse(abc, out result);
                Console.WriteLine(result);
                Console.ReadKey();
            }
        }
