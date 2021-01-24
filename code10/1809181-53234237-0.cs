            MainMenu mmChoice = MainMenu.UNASSIGNED;
            Console.WriteLine("?");
            string sInput = Console.ReadLine();
            if(Enum.TryParse(sInput, out mmChoice))
            {
                switch(mmChoice)
                {
                    case MainMenu.CYLINDER:
                        Console.WriteLine("cylinder");
                        break;
                    case MainMenu.CUBE:
                        Console.WriteLine("cube");
                        break;
                    case MainMenu.SPHERE:
                        Console.WriteLine("sphere");
                        break;
                    case MainMenu.QUIT:
                        Console.WriteLine("quit");
                        break;
                    case MainMenu.UNASSIGNED:
                        break;
                }
            }
            
        
