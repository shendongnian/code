    internal class Program
    {
        private static void Main()
        {
            string expiry = "2018-03-19T23:00:03.0658822+00:00";
            DateTime parsedExpiry = DateTime.Parse(expiry);
            Console.WriteLine(parsedExpiry.ToString());
            Console.ReadKey();
        }
    }
