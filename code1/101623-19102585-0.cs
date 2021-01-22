    class Program
    {
        static void Main(string[] args)
        {
            CheckEquality("a", "a");
            Console.WriteLine("----------");
            CheckEquality("a", "ba".Substring(1));
        }
        static void CheckEquality<T>(T value1, T value2) where T : class
        {
            Console.WriteLine("value1: {0}", value1);
            Console.WriteLine("value2: {0}", value2);
            Console.WriteLine("value1 == value2:      {0}", value1 == value2);
            Console.WriteLine("value1.Equals(value2): {0}", value1.Equals(value2));
            
            if (typeof(T).IsEquivalentTo(typeof(string)))
            {
                string string1 = (string)(object)value1;
                string string2 = (string)(object)value2;
                Console.WriteLine("string1 == string2:    {0}", string1 == string2);
            }
        }
    }
