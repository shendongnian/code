    namespace ConsoleApp1
    {
        class Program
        {
            public static T Merge<T>( T source, IDictionary additional) where T:IDictionary,new()
            {
                var result = new T();
                foreach (var item in additional.Keys)
                {
                    result.Add(item, additional[item]);
                }
                foreach (var item in source.Keys)
                {
                    result.Add(item, source[item]);
                }
                return result;
            }
    
            static void Main(string[] args)
            {
                OrderedDictionary od = new OrderedDictionary();
                od["A"] = 1;
    
                System.Collections.Generic.Dictionary<String, Int32> dictionary = new System.Collections.Generic.Dictionary<String, Int32>();
                dictionary["B"] = 2;
                IDictionary od2 = Merge(od, dictionary);
                Console.WriteLine("output=" + od2["A"]+od2["B"]+od2.GetType());
                IDictionary dictionary2 = Merge(dictionary, od);
                Console.WriteLine("output=" + dictionary2["A"] + dictionary2["B"] + dictionary2.GetType());
                Console.ReadKey();
            }
        }
    }
