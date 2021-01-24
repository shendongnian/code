    public class MyClass : IWorksWithType<TypeA>, IWorksWithType<TypeB>
    {
        public void DoSomething(TypeA fooA) {}
        public void DoSomething(TypeB fooB) {}
        // Implementation of both IWorksWithType<TypeA>.DoSomethingElse()
        // and IWorksWithType<TypeB>.DoSomethingElse()
        public void DoSomethingElse() {}
    }
