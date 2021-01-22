    class Program
    {
        public int? NullableProperty { get; set; }
        static void Main(string[] args)
        {
            var value = "123";
            var program = new Program();
            var property = typeof(Program).GetProperty("NullableProperty");
            var propertyDescriptors = TypeDescriptor.GetProperties(typeof(Program));
            var propertyDescriptor = propertyDescriptors.Find("NullableProperty", false);
            var underlyingType =  
                Nullable.GetUnderlyingType(propertyDescriptor.PropertyType);
            if (underlyingType != null)
            {
                var converter = propertyDescriptor.Converter;
                if (converter != null && converter.CanConvertFrom(typeof(string)))
                {
                    var convertedValue = converter.ConvertFrom(value);
                    property.SetValue(program, convertedValue, null);
                    Console.WriteLine(program.NullableProperty);
                }
            }
        }
    }
