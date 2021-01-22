    public interface eInterface {
        void MethodOnSomeBaseClassThatReturnsCollection();
    }
    public T:SomeBaseClass, eInterface {
    
       public void MethodOnSomeBaseClassThatReturnsCollection() 
       { StaticMethodOnSomeBaseClassThatReturnsCollection() }
    }
    public Collection MethodThatFetchesSomething<T>() where T : SomeBaseClass, eInterface
    { 
       return ((eInterface)(new T()).StaticMethodOnSomeBaseClassThatReturnsCollection();
    }
