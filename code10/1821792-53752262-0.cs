        static void Main(string[] args)
        {
            int[] array = new int[5];
            var index = 0; 
            while (index < array.Length)
            {
                Console.WriteLine("Enter a number:");
                var input = Console.ReadLine();
                var value = 0;
                if (!int.TryParse(input, out value))
                {
                    Console.WriteLine("Error - value entered was not a number");
                }
                else
                {
                    var match = array.Where(a => a == value);
                    if (match.Any())
                    {
                        Console.WriteLine("exists\n");
                    }
                    else
                    {
                        array[index] = value;
                        Console.WriteLine("new\n");
                        index++;
                    }
                }
            }
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadKey();
        }
