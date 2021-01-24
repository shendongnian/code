        class Program
    {
        static void Main(string[] args)
        {
            int instances = CheckValues("Number of instances");
            int numofIpv4 = CheckValues("number of ipv4");
            int numofIpv6 = CheckValues("number of ipv6");
            //etc
        }
        private static int CheckValues(string input)
        {
            int parserValue = 0;
            string enteredValue = string.Empty;
            do
            {
                Console.WriteLine(input);
                enteredValue = Console.ReadLine();
            }
            while (!Int32.TryParse(enteredValue, out parserValue) || parserValue == 0);
            return parserValue;
        }
    }
