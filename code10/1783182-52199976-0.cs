            Console.WriteLine("Enter a, b, c or d:");
            string input = Console.ReadLine();
            switch (input)
            {
                case "a": Console.WriteLine("Success");
                    break;
                case "b":
                    Console.WriteLine("Try again");
                    break;
                case "c":
                    Console.WriteLine("Try again");
                    break;
                case "d":
                    Console.WriteLine("Try again");
                    break;
                default: Console.WriteLine("Enter a, b, c or d:");
                    break;
            }
            Console.ReadLine();
