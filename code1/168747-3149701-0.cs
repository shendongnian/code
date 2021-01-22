    class foo
    {
        public static string ToString()
        {
            return "Static";
        }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(foo.ToString());
            Console.WriteLine(typeof(foo).ToString());
        }
    }
