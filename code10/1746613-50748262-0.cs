    static void Main(string[] args)
    {
        bool herhaal = true;
        do
        {
            Console.Write("Geef een getal : ");
            string Nummer = Console.ReadLine();
    
            if (int.TryParse(Nummer, out int result))
            {
                double kw = Math.Pow(result, 2);
                Console.WriteLine("Kwadraat van {0} is: {1}", Nummer, kw + Environment.NewLine);
                herhaal = false;
            }
            else
            {
                Console.WriteLine("0");
            }
    
        } while (herhaal);
    
        Console.ReadLine();
    }
