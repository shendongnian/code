    static void Main(string[] args)
        {
            Int32? result = null;
            while (result is null)
            {
                Console.WriteLine("Give me a number over 5 bro");
                int x = int.Parse(Console.ReadLine());
                Int32? result = AddNumbers(x, 5);
                if (result is null) continue;
                
                Console.WriteLine(result);
                Console.WriteLine("Press enter to close...");
                Console.ReadLine();
            }
            
        }
