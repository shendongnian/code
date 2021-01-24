            Console.WriteLine("?");
            char sInput = Console.ReadKey().KeyChar;
            Console.WriteLine("");
            switch (sInput)
            {
                case 'a':
                    Console.WriteLine("cylinder");
                    break;
                case 'b':
                    Console.WriteLine("cube");
                    break;
                case 'c':
                    Console.WriteLine("sphere");
                    break;
                case 'd':
                    Console.WriteLine("quit");
                    break;
                default :
                    break; // error handling here
           }
