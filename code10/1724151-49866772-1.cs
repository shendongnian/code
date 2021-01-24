    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. SHC ");
        int UserInput1 = int.Parse(Console.ReadLine());
        if (UserInput1 == 1)
        {
            Console.WriteLine("Mass (kg): ");
            int shcmass = int.Parse(Console.ReadLine());
            Console.WriteLine("Specific Heat Capactiy (J/Kg/°C): ");
            int shcshc = int.Parse(Console.ReadLine());
            Console.WriteLine("Temperature Difference (△Ø): ");
            int shctemp = int.Parse(Console.ReadLine());
            int shcfinal = shcmass * shcshc * shctemp;
            Console.WriteLine("Energy: " + shcfinal);
        }
        Console.ReadLine();
    }
