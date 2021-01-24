    public static void Main()
    {
        double f;
    
        double c;
    
        Console.Write("What is the temperature (in degrees Fahrenheit): ");
    
        while (!double.TryParse(Console.ReadLine(), out f))
        {
            Console.WriteLine("Invalid input");
            Console.WriteLine("What is the temperature (in degrees Fahrenheit): ");
        }
                
        c = (5.0 / 9.0) * (f - 32);
    
        Console.WriteLine("The temperature is " + c + " degrees Celsius");
    
        Console.WriteLine("Press enter to exit.");
    
        Console.ReadLine();
    }
