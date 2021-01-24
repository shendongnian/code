    public static class ConvertIntExtensionMethod
    {
        public static int ConvertToInt(this string str)
        {
            int value;
            value = Convert.ToInt32(str);
            return value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string str = "5";
            //int i = 10;
            //bool result = i.IsGreaterThan(100);
            int result = ConvertIntExtensionMethod.ConvertToInt(str); //Here is the problem
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
