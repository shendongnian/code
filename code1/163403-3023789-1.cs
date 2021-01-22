    public static class Program
    {
        public static void Main(string[] args)
        {
            bool result;
            string value = "yes";
            if (value.TryParseToBoolean(true, out result))
            {
                Console.WriteLine("good input");
            }
            else
            {
                Console.WriteLine("bad input");
            }
        }
    }
