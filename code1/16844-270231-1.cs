    class MyCustomAttribute : Attribute {
        public int[] Values { get; set; }
 
        public MyCustomAttribute(int[] values) {
           this.Values = values;
        }
    }
    [MyCustomAttribute(new int[] { 3, 4, 5 })]
    class MyClass { }
