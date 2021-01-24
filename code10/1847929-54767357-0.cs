    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> list = GetList();
            Console.WriteLine($"{list?.Count}");
            Console.ReadKey();
        }
        public static List<string> GetList()
        {
            return null;
        }
    }
