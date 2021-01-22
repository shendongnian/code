    public class Origin {
       public virtual void SomeSharedOverrideMethod(int data) { }
    }
    class A : Origin {
        
       public override void SomeSharedOverrideMethod(int i) { }
    }
    class A<T> : Origin {
       public override void SomeSharedOverrideMethod(int data) { } 
    }
    class B : Origin
    class B<T> : Origin
