    static class Extension
    {
        public static string Extend(this Array array)
        {
            return "Yes, you can";
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            int[,,,] multiDimArray = new int[10,10,10,10];
            Console.WriteLine(multiDimArray.Extend());
        }
    }
