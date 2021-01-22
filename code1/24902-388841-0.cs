    class Program
    {
        static void Main()
        {
            string propertyName = GetName(() => AppDomain.CurrentDomain);
            Console.WriteLine(propertyName); // prints "CurrentDomain"
            Console.ReadLine();
        }
    
        public static string GetName(Expression<Func<object>> property)
        {
            return property.Body.ToString().Split('.').Last();
        }
    }
