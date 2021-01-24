c#
    class Program
    {
        static void Main(string[] args)
        {
            var results = ToCombo(typeof(Color));
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Hello World!");
        }
        public static IEnumerable<string> ToCombo(Type type)
        {
            if (type.IsEnum)
            {
                return new ArrayList(Enum.GetValues(type)).ToArray().Select(_=>_.ToString());
            }
            return Array.Empty<string>();
        }
    }
