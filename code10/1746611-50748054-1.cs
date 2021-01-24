    static void Main(string[] args)
    {
        int Nummer;
        bool herhaal = true;
        do
        {                
            Console.Write("Geef een getal : ");          
            //only read from the Console ONCE per loop iteration, and always read to a string first
            string input = Console.ReadLine(); 
            //TryParse better than Convert for converting strings to integers
            if (!int.TryParse(input, out Nummer))        
            {
                Console.WriteLine("0");
            }
            else  //only do the second part if the conversion worked
            {
                double kw = Math.Pow(Nummer, 2);
                Console.WriteLine("Kwadraat van {0} is: {1}\n", Nummer, kw);
            }
    
        } while (herhaal);
    }
