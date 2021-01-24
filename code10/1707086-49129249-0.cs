    var sourceCode = (@"
        public class MyAttribute : System.Attribute // < here
        {
            public string Test { get; set; }
        }
    
        [MyAttribute(Test = ""Hello"")]
        public class MyClass { }
    ");
