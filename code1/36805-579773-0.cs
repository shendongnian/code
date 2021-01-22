    class Foo
    {
        public Type someClass;
        ...
    }
    
    class Bar
    {
        private FieldInfo some_Field;
    
        public Assign(string fieldName)
        {
            Foo foo = new Foo();
            some_Field = foo.someClass.GetField(fieldName);
        }
    }
