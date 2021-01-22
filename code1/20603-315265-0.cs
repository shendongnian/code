    class Foo
    {
        public string Bar { get; set; }
    }
    class Program
    {
        static void Main()
        {
            Type type = typeof(Foo); // possibly from a string
            IList list = (IList) Activator.CreateInstance(
                typeof(List<>).MakeGenericType(type));
            object obj = Activator.CreateInstance(type);
            type.GetProperty("Bar").SetValue(obj, "abc", null);
            list.Add(obj);
        }
    }
