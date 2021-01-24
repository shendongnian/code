    var sourceCode = (@"
        using System;
        public class MyAttribute : Attribute
        {
            public string Test { get; set; }
        }
    
        [MyAttribute(Test = ""Hello"")]
        public class MyClass { }
    ");
