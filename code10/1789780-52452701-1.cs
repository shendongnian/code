    namespace Date
    {
        class Program
        {
            enum Day { Mon, Tue, Wed, Thu, Fri, Sat, Sun };
            enum Month { January, February, March, April, May, June, July, August, September, October, November, December };
    
            static void Main(string[] args)
            {
                Month month;
                Day week;
                int day, year;
                do
                {
                    Console.Write("Enter Month in Numeric form (Example 1 for January): ");
                } while (!Enum.TryParse(Console.ReadLine(), out month));
                do
                {
                    Console.Write("Enter Day of the week in Numeric form (Example 1 for Monday): ");
                } while (!Enum.TryParse(Console.ReadLine(), out week));
                do
                {
                    Console.Write("Enter day in Numeric form (Example 15): ");
                } while (!int.TryParse(Console.ReadLine(), out day));
                do
                {
                    Console.Write("Enter year in Numeric form (Example 2018): ");
                } while (!int.TryParse(Console.ReadLine(), out year));
    
                Console.WriteLine(string.Format("The date you entered is: {3}, {0} {1}, {2}", month, day, year, week));
            }
        }
    }
