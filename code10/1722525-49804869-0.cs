    public class TypeA {}
    public class TypeB {}
    
    public interface IWorksWithType<T>
    {
         void DoSomething(T foo);
         void DoSomethingElse();
    }
    
    public class MyClass : IWorksWithType<TypeA>, IWorksWithType<TypeB>
    {
        public void DoSomething(TypeA fooA) {}
        public void DoSomething(TypeB fooB) {} 
        // Note the syntax here - this indicates which interface
        // method you're implementing        
        void IWorksWithType<TypeA>.DoSomethingElse() {}
        void IWorksWithType<TypeB>.DoSomethingElse() {}
    }
