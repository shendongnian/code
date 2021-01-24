    class Program
    {
        private static readonly Dictionary<string, RackOfBeverages> Beverages =
            new Dictionary<string, RackOfBeverages>
            {
                {"COKE", new RackOfBeverages("Coke", 2)},
                {"SPRITE", new RackOfBeverages("Sprite", 20)},
                //etc.
            };
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the machine\r\nType a selection (type \"Exit\" to quit)");
            while (true)
            {
                var selection = Console.ReadLine();
                //did the user enter the name of a drink
                if (Beverages.Keys.Contains(selection, StringComparer.OrdinalIgnoreCase))
                {
                    var beverage = Beverages[selection.ToUpper()];
                    //was there enough to dispense a drink
                    if (beverage.Dispense())
                    {
                        Console.WriteLine($"Here's your {beverage.Label}");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, no {beverage.Label} for you");
                    }
                }
                //or, perhaps, the user chose to exit the app
                else if (selection.ToUpper() == "EXIT")
                {
                    Console.WriteLine("Exiting");
                    break;
                }
                //finally, if the user didn't enter anything I understand 
                //let him/her know and then let him/her try again
                else
                {
                    Console.WriteLine("Pick a valid selection");
                }
            }
            
        }
    }
