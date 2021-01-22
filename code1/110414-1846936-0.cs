    namespace NS
    {
        class Program
        {
            static IEnumerable<int> GetInts()
            {
                yield return 1;
            }
    
            static void Main()
            {
                var i = GetInts();
                var type = i.GetType();
                var isEnumerableOfT = type.GetInterfaces()
                    .Any(ti => ti.IsGenericType
                         && ti.GetGenericTypeDefinition() == typeof(IEnumerable<>));
                Console.WriteLine(isEnumerableOfT);
            }
        }
    }
