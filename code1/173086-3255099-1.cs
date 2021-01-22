    class Program
    {
        static void Main(string[] args)
        {
            int x = 4, y = 4, z = 4;
            Console.WriteLine(4.IsEqualToAllIn(x, y, z).ToString());
            //prints True
            string a = "str", b = "str1", c = "str";
            Console.WriteLine("str".IsEqualToAllIn(a, b, c).ToString());
            //prints False
        }
    }
    public static class MyExtensions
    {
        public static bool IsEqualToAllIn<T>(this T valueToCompare, params T[] list)
        {
            bool prevResult = true;
            if (list.Count() > 1)
                prevResult = list[0].IsEqualToAllIn(list.Skip(1).ToArray());
            return (valueToCompare.Equals(list[0])) && prevResult;
        }
    }
