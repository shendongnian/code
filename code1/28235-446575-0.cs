    class Program
    {
        public int? NullableProperty { get; set; }
        static void Main(string[] args)
        {
            var value = "123";
            var program = new Program();
            var property = typeof(Program).GetProperty("NullableProperty");
            var propertyType = property.PropertyType;
            if (propertyType.IsGenericType && 
                propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var genericArgument = propertyType.GetGenericArguments().First();
                var converter = TypeDescriptor.GetConverter(genericArgument);
                if (converter != null && converter.CanConvertFrom(typeof(string)))
                {
                    var convertedValue = converter.ConvertFrom(value);
                    property.SetValue(program, convertedValue, null);
                    Console.WriteLine(program.NullableProperty);
                }
            }
        }
    }
