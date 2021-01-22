    class SomeClass
    {
    
        struct MyStruct
        {
            private readonly string label;
            private readonly int id;
            public MyStruct (string label, int id)
            {
                this.label = label;
                this.id = id;
            }
            public string Label { get { return label; } }
            public string Id { get { return id; } }
        }
    
        static readonly IList<MyStruct> MyArray = new ReadOnlyCollection<MyStruct>
            (new[] {
                 new MyStruct ("a", 1),
                 new MyStruct ("b", 5),
                 new MyStruct ("q", 29)
            });
    }
