    public class Program
    {
        public static void Main(string[] args)
        {
            var original = new Values();
            original.One = true;
            original.Two = false;
            var copy = CopyValuesToAnotherValues(original);
            Console.WriteLine($"one value: {copy.One}; two value: {copy.Two}");
            Console.ReadLine();
        }
        public static AnotherValues CopyValuesToAnotherValues(Values originalValue)
        {
            var valuesProperties = typeof(Values).GetProperties();
            var anotherValuesProperties = typeof(AnotherValues).GetProperties();
            var anotherValueInstance = new AnotherValues();
            foreach (PropertyInfo property in valuesProperties)
            {
                if (property.PropertyType != typeof(bool))
                {
                    continue;
                }
                var booleanValue = property.GetValue(originalValue);
                anotherValuesProperties.Where(x => x.Name == property.Name).Single().SetValue(anotherValueInstance, booleanValue);
            }
            return anotherValueInstance;
        }
    }
    public class Values
    {
        public bool One { get; set; }
        public bool Two { get; set; }
    }
    public class AnotherValues
    {
        public bool One { get; set; }
        public bool Two { get; set; }
    }
