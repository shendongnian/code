    static void MenuOptions(string[,] animal)
    {
        while (true)
        { 
            int userChoice;
    
            do
            {
                Console.Clear();
                Console.WriteLine("\nChoose one of the following options:\n");
    
                Console.WriteLine("[ 1 ] Animals");
                Console.WriteLine("[ 2 ] Clients");
                Console.WriteLine("[ 0 ] Quit application\n");
    
            } while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 0 || userChoice > 2);
    
            Console.Clear();
    
            switch (userChoice)
            {
                case 1:
                    menuAnimal(animal);
                    break;
                case 2:
                    //menuClient(client);
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Try again!!");
                    break;
            }
        }
    }
