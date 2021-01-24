    public class Class1
    {
        public IList<string> List { get; } = new List<string>();
        public static Class1 M()
        {
            return new Class1
            {
                List =
                {
                "foo", "bar"
                }
            };
        }
    }
