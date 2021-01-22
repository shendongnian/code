    static class Program
    {
        static void Main()
        {
            var people = new[] {new Person {Age = 20}, new Person {Age = 18}, new Person {Age = 42}, new Person {Age = 51}};
            var averageAgeFunction = CreateIntegerAverageFunction<Person>("Age");
            var average = averageAgeFunction(people);
            Console.WriteLine(average);
        }
        public static Func<IEnumerable<T>, double> CreateIntegerAverageFunction<T>(string property)
        {
            var type = typeof(T);
            var propertyInfo = type.GetProperty(property);
            if (propertyInfo.PropertyType.Equals(typeof(int)))
            {
                var instanceParameter = Expression.Parameter(type, "instance");
                var expression = Expression.Property(instanceParameter, propertyInfo);
                var func = Expression.Lambda<Func<T, int>>(expression, instanceParameter).Compile();
                return c => c.Average(func);
            }
            throw new Exception();
        }
    }
    public class Person
    {
        public int Age { get; set; }
    }
