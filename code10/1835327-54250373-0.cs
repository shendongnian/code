    using System.Collections.Generic;
    
    namespace Test
    {
        public static class Test
        {
            public static void Execute<TKey, TValue>(this IEnumerable<IEnumerable<KeyValuePair<TKey, TValue>>> enums)
            {
    
            }
    
            public static void Execute<T>(this IEnumerable<T> enums)
            {
            }
        }
    
        class Program
        {
            void Main()
            {
                IEnumerable<IEnumerable<KeyValuePair<string, string>>> data = new[] {
                    new Dictionary<string, string> (){
                        {"Name" , "ITWeiHan" }
                    }
                };
                data.Execute();
            }
        }
    }
