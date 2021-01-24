              do
                {
                    Console.WriteLine("Select Menu:(1)Triangle (2)Rectangle (Q)Quit");
    
                    menu = Console.ReadLine();
                    switch (menu.ToUpper())
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                        case "Q":
                            return;
                    }
    
                    Console.WriteLine(menu + " is selected");
                } while (true);
