    public interface eInterface {
        void StaticMethodOnSomeBaseClassThatReturnsCollection();
    }
    
    public Collection MethodThatFetchesSomething<T>()    
        where T : SomeBaseClass, eInterface
    { 
       return ((eInterface)typeof(T).StaticMethodOnSomeBaseClassThatReturnsCollection();
    }
