    public class MyClass
    {
        public string StringProp { get; set; }
    }
.....
            var list = new List<MyClass>();
            list.Add(new MyClass { StringProp = "Foo" });
            list.Add(new MyClass { StringProp = "Bar" });
            list.Add(new MyClass { StringProp = "Baz" });
            string joined = list.ToDelimitedString(m => m.StringProp);
            Console.WriteLine(joined);
