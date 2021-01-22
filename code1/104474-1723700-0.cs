    class ClassA<T> where T : ClassA<T>, new()
    {
        public T DoSomethingAndReturnNewObject()
        {
            return new T();
        }
    }
    class ClassB : ClassA<ClassB>
    {
    }
