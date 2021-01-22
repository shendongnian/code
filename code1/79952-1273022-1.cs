    public static class ExtensionMethods
    {
        public static void CopyPropertiesTo<T>(this T source, T dest)
        {
            var plist = from prop in typeof(T).GetProperties() where prop.CanRead && prop.CanWrite select prop;
            foreach (PropertyInfo prop in plist)
            {
                prop.SetValue(dest, prop.GetValue(source, null), null);
            }
        }
    }
    class Foo
    {
        public int Age { get; set; }
        public float Weight { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return string.Format("Name {0}, Age {1}, Weight {2}", Name, Age, Weight);
        }
    }
    static void Main(string[] args)
    {
         Foo a = new Foo();
         a.Age = 10;
         a.Weight = 20.3f;
         a.Name = "Ralph";
         Foo b = new Foo();
         a.CopyPropertiesTo<Foo>(b);
         Console.WriteLine(b);
     }
