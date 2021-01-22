    interface IAttributeStore
    {
        T GetAttribute<T>(string key);
    }
    class Example : IAttributeStore
    {
        public int ExampleID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        static Dictionary<string, Delegate> _AttributeAccessors;
        static Example()
        {
            _AttributeAccessors = new Dictionary<string, Delegate>();
            _AttributeAccessors.Add("ExampleID", new Func<Example, int>((example) => example.ExampleID));
            _AttributeAccessors.Add("FirstName", new Func<Example, string>((example) => example.FirstName));
            _AttributeAccessors.Add("LastName", new Func<Example, string>((example) => example.LastName));
        }
        #region IAttributeStore Members
        public T GetAttribute<T>(string key)
        {
            Delegate accessor;
            if (_AttributeAccessors.TryGetValue(key, out accessor))
            {
                Func<Example, T> func = accessor as Func<Example, T>;
                if (func != null)
                    return func(this);
                else
                    throw new Exception(string.Format("The attribute with the given key \"{0}\" is not of type [{1}].", key, typeof(T).FullName));
            }
            else
            {
                throw new ArgumentException(string.Format("No attribute exists with the given key: \"{0}\".", key), "key");
            }
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            Example example = new Example() { ExampleID = 12345, FirstName = "Funky", LastName = "Town" };
            Console.WriteLine(example.GetAttribute<int>("ExampleID"));
            Console.WriteLine(example.GetAttribute<string>("FirstName"));
            Console.WriteLine(example.GetAttribute<string>("LastName"));
        }
    }
