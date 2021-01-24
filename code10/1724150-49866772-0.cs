    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. SHC ");
        int UserInput1 = Console.ReadLine();
        if (UserInput1 == 1)
        {
            Console.WriteLine("Mass (kg): ");
            int shcmass = Console.ReadLine();
            Console.WriteLine("Specific Heat Capactiy (J/Kg/°C): ");
            int shcshc = Console.ReadLine();
            Console.WriteLine("Temperature Difference (△Ø): ");
            int shctemp = Console.ReadLine();
            int shcfinal = shcmass * shcshc * shctemp;
            Console.WriteLine("Energy: " + shcfinal);
        }
        Console.ReadLine();
    }
