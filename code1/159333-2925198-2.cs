    static class Program
    {
        static void Main()
        {
            var watch = new Stopwatch();
            var people = new List<Person>();
            for(var i = 0; i < 1000000; i++)
            {
                people.Add(new Person{Age = i});
            }
            watch.Start();
            
            var averageAgeFunction = CreateIntegerAverageFunction<Person>("Age");
            Console.WriteLine(averageAgeFunction(people));
            Console.WriteLine(watch.ElapsedTicks);
            watch.Stop();
            watch.Reset();
            watch.Start();
            Console.WriteLine(people.GetIntAverage("Age"));
            Console.WriteLine(watch.ElapsedTicks);
            watch.Stop();
        }
        public static Func<IEnumerable<T>, double> CreateIntegerAverageFunction<T>(string property)
        {
            var type = typeof(T);
            var propertyInfo = type.GetProperty(property);
            if (propertyInfo.PropertyType.Equals(typeof(int)))
            {
                // Create an expression that will get the property value from the instance
                var instanceParameter = Expression.Parameter(type, "instance");
                var expression = Expression.Property(instanceParameter, propertyInfo);
                var func = Expression.Lambda<Func<T, int>>(expression, instanceParameter).Compile();
                return c => c.Average(func);
            }
            throw new Exception();
        }
        public static double GetIntAverage<T>(this IEnumerable<T> instances, string property)
        {
            var type = typeof (T);
            var propertyInfo = type.GetProperty(property);
            if(propertyInfo.PropertyType.Equals(typeof(int)))
            {
                return instances.Average(t => (int) propertyInfo.GetValue(t, null));
            }
            throw new Exception();
        }
    }
    public class Person
    {
        public int Age { get; set; }
    }
