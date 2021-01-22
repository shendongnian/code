    class ClassA
    {
        public virtual ClassA DoSomethingAndReturnNewObject()
        {
            return new ClassA();
        }
    }
    abstract class ClassA<T> : ClassA where T : ClassA<T>, new()
    {
        public override ClassA DoSomethingAndReturnNewObject()
        {
            return new T();
        }
    }
    class ClassB : ClassA<ClassB> { }
    class ClassC : ClassA<ClassC> { }
