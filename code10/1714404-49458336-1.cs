    public static int FahrToCel(int fahr)
        {
            int cel = (fahr - 32) * 5 / 9;
            return cel;
        }
        public static void Main(string[] args)
        {
            int startTempLimit = 0;
            int lowerTempLimit = 73;
            int upperTempLimit = 77;
            int celsius;
            int fahrenheit;
            do
            {
                Console.WriteLine("Skriv in Fahrenheit grader: ");
                while (true)
                {
                    try
                    {
                        fahrenheit = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Endast heltal kan matas in, försök igen!");
                        Console.WriteLine("\nSkriv in Fahrenheit grader: ");
                    }
                }
                celsius = FahrToCel(fahrenheit);
                if (celsius < startTempLimit)
                {
                    Console.WriteLine("Bastun är ej påslagen. Du måste sätta på bastun. Värme i bastu {0}C.", celsius);
                }
                else if (celsius < lowerTempLimit)
                {
                    Console.WriteLine("Bastun är inte tillräckligt varm. Värme i bastun {0}C, skruva upp värmen", celsius);
                }
                else if (celsius > upperTempLimit)
                {
                    Console.WriteLine("Bastun är för varm. Värme i bastun {0}C, skruva ner värmen", celsius);
                }
                else
                {
                    Console.WriteLine("Bastun är tillräckligt varm för att kunna basta. Värme i bastun {0}C.", celsius);
                }
            }
            while (celsius < lowerTempLimit || celsius > upperTempLimit);
        }
