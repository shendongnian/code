    using System;
    
    public class Program
    {
     public static void Main(string[] args)
     {
        int _pLicense = 50;
        int _sLicense = 100;
        int _eLicense = 150;
        String lType;
        int nSeats;
        int Cost;
    Console.WriteLine("\n1.Personal License\n2.Startup License\n3.Enterprise License");
            Console.WriteLine("Enter the license type");
            lType = Console.ReadLine();
            //lType = char.Parse(Console.ReadLine());
    
    
    switch(lType)
        {
            case "1":
                Console.WriteLine("Enter the number of seats");
                nSeats = int.Parse(Console.ReadLine());
                //Console.WriteLine(_pLicense);
                Cost = _pLicense*nSeats;
                Console.WriteLine("Personal License Cost : $" + Cost);
                break;
            case "2":
                Console.WriteLine("Enter the number of seats");
                nSeats = int.Parse(Console.ReadLine());
                //Console.WriteLine(_sLicense);
                Cost = (_sLicense * nSeats);
                Console.WriteLine("Startup License Cost : $" + Cost);
                break;
            case "3":
                Console.WriteLine("Enter the number of seats");
                nSeats = int.Parse(Console.ReadLine());
                //Console.WriteLine(_pLicense);
                Cost = (_eLicense * nSeats);
                Console.WriteLine("Enterprise License Cost : $" + Cost);
                break;
            default:
            Console.WriteLine("Invalid Type");
               break;
        }
    }
