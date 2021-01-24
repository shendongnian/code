    public abstract class BaseClass
    {
        // restrict to children of BaseClass
        public T CreateCopy<T>() where T: BaseClass, new()
        {
            var copy = new T();
            // get properties that you actually care about
            var properties = typeof(T).GetProperties()
                .Where(x => x.GetCustomAttribute<CopiablePropertyAttribute>() != null);
            foreach (var property in properties)
            {
                // set the value to the copy from the instance that called this method
                property.SetValue(copy, property.GetValue(this));
            }
            return copy;
        }
    }
    public class DerivedClass : BaseClass
    {
        [CopiableProperty]
        public string Property1 { get; set; }
        [CopiableProperty]
        public int Property2 { get; set; }
        public int Property3 { get; set; }
        public override string ToString()
        {
            return $"{Property1} - {Property2} - {Property3}";
        }
    }
    static void Main(string[] args)
    {
        var original = new DerivedClass
        {
            Property1 = "Hello",
            Property2 = 123,
            Property3 = 500
        };
        var copy = original.CreateCopy<DerivedClass>();
        Console.WriteLine(original);
        Console.WriteLine(copy);
        Console.ReadLine();
    }
