    public static void Main(string[] args)
    {
        int nSeats = 0;
        Console.WriteLine("\n1.Personal License\n2.Startup License\n3.Enterprise License");
        Console.WriteLine("Enter the license type");
        var lType = Console.ReadLine();  //ReadLine returns a string, so it will automatically make lType a string
        int _LicenseCost = lType == "1" ? 50 : lType == "2" ? 100 : lType == "3" ? 150 : 0;
        if(_LicenseCost > 0)
        {
            while(true)
            {
                Console.WriteLine("Enter the number of seats");
                if(int.TryParse(Console.ReadLine(), out nSeats))
                    break;
                else
                    Console.WriteLine("Please enter a valid number");
            }
            Console.WriteLine((lType == "1" ? "Personal" : lType == "2" ? "Startup" : lType == "3" ? "Enterprise" : "") + $" License Cost : ${_LicenseCost * nSeats}");
        }
        else
            Console.WriteLine("License type is not valid. Good bye!");
    }
