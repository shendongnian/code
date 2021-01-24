    while (UpperCase(menuChoice)!="EXIT")
    {
    
                Console.WriteLine("Type A to go to Fahrenheit Converter");
                Console.WriteLine("Type B to go to Coin Change");
                Console.WriteLine("Type C to go to Number Pattern");
                string menuChoice = Console.ReadLine().ToUpper();
    
                switch (menuChoice)
                {
                    case "A":
                        fahrenheitConverter();
                        break;
                    case "B":
    
                        break;
                    case "C":
    
                        break;
                    case "D":
                        break;
                }
    
    }
