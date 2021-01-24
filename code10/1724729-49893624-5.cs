    public class Program
    {
        public static void Main()
        {
            var matches = typeof(Parent).GetFullPropertyNames("Ticks");
            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
            Console.ReadKey();
        }
    }
