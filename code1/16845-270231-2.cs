    class MyCustomAttribute : Attribute {
        public int[] Values { get; set; }
        public MyCustomAttribute(params int[] values) {
           this.Values = values;
        }
    }
    [MyCustomAttribute(3, 4, 5)]
    class MyClass { }
