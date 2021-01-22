    class Program
    {
        static void Main(string[] args)
        {
            string stringtotal = "";
            string chartotal = "";
            Stopwatch stringconcat = new Stopwatch();
            Stopwatch charconcat = new Stopwatch();
            stringconcat.Start();
            for (int i = 0; i < 100000; i++)
            {
                stringtotal += ".";
            }
            stringconcat.Stop();
            charconcat.Start();
            for (int i = 0; i < 100000; i++)
            {
                chartotal += '.';
            }
            charconcat.Stop();
            Console.WriteLine("String: " + stringconcat.Elapsed.ToString());
            Console.WriteLine("Char  : " + charconcat.Elapsed.ToString());
            Console.ReadLine();
        }
    }
