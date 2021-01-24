        try
            {
                sel = int.Parse(Console.ReadLine());
                switch (sel)
                {
                    case 1:
                        SecondMenu();
                        break;
                    case 2:
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Sorry that is not correct format! Please restart!");
                        MainMenu();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Sorry that is not correct format! Please restart!");
                MainMenu();
            }
   
