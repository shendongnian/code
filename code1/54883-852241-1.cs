    static class Program
    {
        static void Main()
        {
            object obj = new Dictionary<int, string> {
                { 123, "abc" }, { 456, "def" } };
    
            foreach (Type iType in obj.GetType().GetInterfaces())
            {
                if (iType.IsGenericType && iType.GetGenericTypeDefinition()
                    == typeof(IDictionary<,>))
                {
                    typeof(Program).GetMethod("ShowContents")
                        .MakeGenericMethod(iType.GetGenericArguments())
                        .Invoke(null, new object[] { obj });
                    break;
                }
            }
        }
        public static void ShowContents<TKey, TValue>(
            IDictionary<TKey, TValue> data)
        {
            foreach (var pair in data)
            {
                Console.WriteLine(pair.Key + " = " + pair.Value);
            }
        }    
    }
