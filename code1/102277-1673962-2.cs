    public class TestHarness
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            class1.Foo = "foo";
            Class2 class2 =
                new Class2
                {
                    Foo = "foo"
                };
        }
    }
    public class Class1
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
    }
    public class Class2
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
    }
