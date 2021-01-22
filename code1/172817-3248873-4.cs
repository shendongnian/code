    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    class AttributeStoreAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    class StoredAttributeAttribute : Attribute
    {
        public string Key { get; set; }
    }
    public static class AttributeStore<T>
    {
        static Dictionary<string, Delegate> _AttributeAccessors;
        public static void Initialize()
        {
            _AttributeAccessors = new Dictionary<string, Delegate>();
            Type type = typeof(T);
            // let's keep it simple and just do properties for now
            foreach (var property in type.GetProperties())
            {
                var attributes = property.GetCustomAttributes(typeof(StoredAttributeAttribute), true);
                if (attributes != null && attributes.Length > 0)
                {
                    foreach (object objAttribute in attributes)
                    {
                        StoredAttributeAttribute attribute = objAttribute as StoredAttributeAttribute;
                        if (attribute != null)
                        {
                            string key = attribute.Key;
                            // use the property name by default
                            if (string.IsNullOrEmpty(key))
                                key = property.Name;
                            if (_AttributeAccessors.ContainsKey(key))
                                throw new Exception(string.Format("An attribute accessor has already been defined for the given key \"{0}\".", key));
                            Type typeOfFunc = typeof(Func<,>).MakeGenericType(type, property.PropertyType);
                            Delegate accessor = Delegate.CreateDelegate(typeOfFunc, null, property.GetGetMethod());
                            _AttributeAccessors.Add(key, accessor);
                        }
                    }
                }
            }
        }
        public static object GetAttribute(T store, string key)
        {
            if (_AttributeAccessors == null)
                Initialize();
            Delegate accessor;
            if (_AttributeAccessors.TryGetValue(key, out accessor))
            {
                return accessor.DynamicInvoke(store);
            }
            else
            {
                throw new ArgumentException(string.Format("No attribute exists with the given key: \"{0}\" on attribute store [{1}].", key, typeof(T).FullName), "key");
            }
        }
        public static TResult GetAttribute<TResult>(T store, string key)
        {
            if (_AttributeAccessors == null)
                Initialize();
            Delegate accessor;
            if (_AttributeAccessors.TryGetValue(key, out accessor))
            {
                Func<T, TResult> func = accessor as Func<T, TResult>;
                if (func != null)
                    return func(store);
                else
                    throw new Exception(string.Format("The attribute with the given key \"{0}\" on attribute store [{1}] is not of type [{2}].", key, typeof(T).FullName, typeof(TResult).FullName));
            }
            else
            {
                throw new ArgumentException(string.Format("No attribute exists with the given key: \"{0}\" on attribute store [{1}].", key, typeof(T).FullName), "key");
            }
        }
    }
    public static class AttributeStoreExtensions
    {
        public static object GetAttribute<T>(this T store, string key)
        {
            return AttributeStore<T>.GetAttribute(store, key);
        }
        public static TResult GetAttribute<T, TResult>(this T store, string key)
        {
            return AttributeStore<T>.GetAttribute<TResult>(store, key);
        }
    }
    [AttributeStore]
    class Example
    {
        [StoredAttribute]
        public int ExampleID { get; set; }
        [StoredAttribute]
        public string FirstName { get; set; }
        [StoredAttribute]
        public string LastName { get; set; }
    }
    [AttributeStore]
    class Example2
    {
        [StoredAttribute]
        [StoredAttribute(Key = "ID")]
        public int ExampleID { get; set; }
        [StoredAttribute]
        [StoredAttribute(Key = "First")]
        public string FirstName { get; set; }
        [StoredAttribute]
        [StoredAttribute(Key = "Last")]
        public string LastName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Example example = new Example() { ExampleID = 12345, FirstName = "Funky", LastName = "Town" };
            Console.WriteLine(example.GetAttribute("ExampleID"));
            Console.WriteLine(example.GetAttribute("FirstName"));
            Console.WriteLine(example.GetAttribute("LastName"));
            Example2 example2 = new Example2() { ExampleID = 12345, FirstName = "Funky", LastName = "Town" };
            // access attributes by the default key (property name)
            Console.WriteLine(example2.GetAttribute("ExampleID"));
            Console.WriteLine(example2.GetAttribute("FirstName"));
            Console.WriteLine(example2.GetAttribute("LastName"));
            // access attributes by the explicitly specified key
            Console.WriteLine(example2.GetAttribute("ID"));
            Console.WriteLine(example2.GetAttribute("First"));
            Console.WriteLine(example2.GetAttribute("Last"));
        }
    }
