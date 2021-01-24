    using System;
    class FooAttribute : Attribute { public string Value { get; set; } }
    
    [Foo(Value = "abc")]
    class Bar
    {
        static void Main()
        {
            var attrib = (FooAttribute)typeof(Bar)
                .GetCustomAttributes(typeof(FooAttribute), false)[0];
            Console.WriteLine(attrib.Value); // "abc"
            attrib.Value = "def";
            Console.WriteLine(attrib.Value); // "def"
    
            // now re-fetch
            attrib = (FooAttribute)typeof(Bar)
                .GetCustomAttributes(typeof(FooAttribute), false)[0];
            Console.WriteLine(attrib.Value); // "abc"
        }
    }
