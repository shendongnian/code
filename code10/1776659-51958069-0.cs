    private static int GetInput(string v)
    {
        Console.Write(v);
        string strradius = Console.ReadLine();
    
        if (string.IsNullOrEmpty(strradius)
        {
            Console.WriteLine("You must enter a value.");
            return 0;
        }
    
        int intradius;
    
        bool result = int.TryParse(strradius);
        if (!result)
            Console.WriteLine("You must enter a valid number.");
        else if (intradius < 1)
            Console.WriteLine("Your number is out of range");
    
        Console.WriteLine("Okay");
        return intradius;
    } 
