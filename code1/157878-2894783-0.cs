    class Program
    {
        static void Main(string[] args)
        {
            var bar = new Bar();
            var foo = new Foo {A = 10, B = "Hello World"};
            
            foo.CopyTo(bar);
            Console.WriteLine("{0} - {1}", bar.A, bar.B);
        }
    }
    public static class Extensions
    {
        public static void CopyTo(this object source, object destination)
        {
            var sourceType = source.GetType();
            var destinationType = destination.GetType();
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            var properties = sourceType.GetProperties(flags);
            foreach (var sourceProperty in properties)
            {
                var destinationProperty = destinationType.GetProperty(sourceProperty.Name, flags);
                if (destinationProperty.PropertyType.Equals(sourceProperty.PropertyType))
                {
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);
                }
            }
        }
    }
