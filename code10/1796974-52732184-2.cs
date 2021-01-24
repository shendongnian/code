    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter the current day of the week.");
                string currentday = Console.ReadLine();
                days day;
                if (Enum.TryParse<days>(currentday, out day))
                {
                    Console.WriteLine("Good job.  Today is " + currentday);
                    Console.ReadLine();
                }
                else
                {
                    throw new OverflowException(); // try parse failed. enum not valid! Why OverflowException?
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Not a valid day");
            }
            Console.ReadLine();
        }
        public enum days
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }
    }
