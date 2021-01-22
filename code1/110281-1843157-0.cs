    abstract class ClassA
    {
        private static class InternalClass<T> {
            public static string Value;
        }
        public string GetValue()
        {
            return (string)typeof(InternalClass<>)
                  .MakeGenericType(GetType())
                  .GetField("Value", BindingFlags.Public | BindingFlags.Static)
                  .GetValue(null);
        }
    }
