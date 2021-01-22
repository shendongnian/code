       do
             {
                switch (Console.ReadKey().KeyChar.ToString())
                {
                    case "U":
                        Console.WriteLine("Scrolling up");
                        continue;
                    case "J":
                        Console.WriteLine("Scrolling down");
                        continue;
                    case "D": //DONE (exit out of this Do Loop)
                        break;
                    case "Q": //QUIT (exit out to main menu)
                        return;
                    default:
                        Console.WriteLine("Continuing");
                        continue;
                }
                break;
            } while (true);
            Console.WriteLine("Exited");
