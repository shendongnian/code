    static class Program
    {
        static void Main()
        {
            var people = new List<Person>();
            for (var i = 0; i < 1000000; i++)
            {
                var person = new Person { Age = i };
                person.Details.Height = i;
                person.Details.Name = i.ToString();
                people.Add(person);
            }
            var averageAgeFunction = CreateIntegerAverageFunction<Person>("Age");
            var averageHeightFunction = CreateIntegerAverageFunction<Person>("Details.Height");
            var averageNameLengthFunction = CreateIntegerAverageFunction<Person>("Details.Name.Length");
            Console.WriteLine(averageAgeFunction(people));
            Console.WriteLine(averageHeightFunction(people));
            Console.WriteLine(averageNameLengthFunction(people));
        }
        public static Func<IEnumerable<T>, double> CreateIntegerAverageFunction<T>(string property)
        {
            var type = typeof(T);
            var properties = property.Split('.');   // Split the properties
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
            Expression expression = parameterExpression;
            // Iterrate over the properties creating an expression that will get the property value
            for (int i = 0; i < properties.Length; i++)
            {
                var propertyInfo = type.GetProperty(properties[i]);
                expression = Expression.Property(expression, propertyInfo);  // Use the result from the previous expression as the instance to get the next property from
                type = propertyInfo.PropertyType;
            }
            // Ensure that the last property in the sequence is an integer
            if (type.Equals(typeof(int)))
            {
                var func = Expression.Lambda<Func<T, int>>(expression, parameterExpression).Compile();
                return c => c.Average(func);
            }
            throw new Exception();
        }
    }
    public class Person
    {
        private readonly Detials _details = new Detials();
        public int Age { get; set; }
        public Detials Details { get { return _details; } }
    }
    public class Detials
    {
        public int Height { get; set; }
        public string Name { get; set; }
    }
