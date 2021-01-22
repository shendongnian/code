    static class ExtensionMethods
    {
        public static T InitialiseObjectIfNull<T>(this T obj)
            where T : class, new()
        {
            return obj ?? new ();
        }
    }
    
    class SomeClass
    {
        public string SomeProperty { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            SomeClass someClass = null;
    
            someClass = someClass.InitialiseObjectIfNull();
        }
    }
