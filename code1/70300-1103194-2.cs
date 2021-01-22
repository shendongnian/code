    public class Origin {
       public virtual void SomeSharedOverrideMethod(int data) { }
    }
    class A : Origin {
        
       public void MethodForAImpl() {
           base.SomeSharedOverrideMethod(23);
       }
    }
    class A<T> : Origin {
       public void MethodForGenericAImpl() {
           base.SomeSharedOverrideMethod(45);
       }
    }
    class B : Origin
    class B<T> : Origin
