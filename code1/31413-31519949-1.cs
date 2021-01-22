    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GenericCaster<string>(12345));
            Console.WriteLine(GenericCaster<object>(new { a = 100, b = "string" }) ?? "null");
            Console.WriteLine(GenericCaster<double>(20.4));
            
            //prints:
            //12345
            //null
            //20.4
    
            Console.WriteLine(GenericCaster2<string>(12345));
            Console.WriteLine(GenericCaster2<object>(new { a = 100, b = "string" }) ?? "null");
            
            //will not compile -> 20.4 does not comply due to the type constraint "T : class"
            //Console.WriteLine(GenericCaster2<double>(20.4));
        }
    
        static T GenericCaster<T>(object value, T defaultValue = default(T))
        {
            T castedValue;
            try
            {
                castedValue = (T) Convert.ChangeType(value, typeof(T));
            }
            catch (Exception)
            {
                castedValue = defaultValue;
            }
    
            return castedValue;
        }
    
        static T GenericCaster2<T>(object value, T defaultValue = default(T)) where T : class
        {
            T castedValue;
            try
            {
                castedValue = Convert.ChangeType(value, typeof(T)) as T;
            }
            catch (Exception)
            {
                castedValue = defaultValue;
            }
    
            return castedValue;
        }
    }
