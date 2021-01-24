    public static void Main(string[] args)
    {
        Console.WriteLine("Skriv in Fahrenheit: ");
        try
        {
            int fahrenheit = int.Parse(Console.ReadLine());
        }
        catch(Exception e)
        {
            //Do error handling i.e. prompt user for a valid number
        }
        
        //Användaren skriver in ett värde som lagras i fahrenheit
        int celsius = FahrToCel(fahrenheit);
        /* I celsius finns nu antal grader omvandlat från fahrenheit till celsius. */
        /*Här får lowerTempLimit värdet 77 
         * &  upperTempLimit = 77 */
        int lowerTempLimit = 73;
        int upperTempLimit = 77;
        /* While-do loop som breaker efter en iteration.
        *If satserna skriver utvärmen i bastun och säger till om temperatur ska sänkas eller höjas beroende på temperaturn i celsius. 
        * Om temperaturn är mellan 73 - 77 grader, så har bastun godtyckligt bra temperatur */
        do
        {
            if (celsius < lowerTempLimit)
            {
                Console.WriteLine("Bastun är inte tillräckligt varmt. Värme i bastun {0}, skruva upp värmen", celsius);
            }
            else if (celsius > upperTempLimit)
            {
                Console.WriteLine("Bastun är för varmt. Värme i bastun {0}, skruva ner värmen", celsius);
            }
            else
            {
                Console.WriteLine("Bastun är tillräckligt varmt för att kunna basta. Värme i bastun {0}", celsius);
            }
        }
        while (celsius < lowerTempLimit || celsius > upperTempLimit);
        Console.Write("Press any key to continue . . . ");
        Console.ReadKey();
    }
