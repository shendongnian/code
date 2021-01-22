    public class Origin<T> {
       public virtual void SomeSharedOverrideMethod(T data) { }
    }
    class A : Origin<int> {
        
       public override void SomeSharedOverrideMethod(int i) { }
    }
    class A<T> : Origin<T> {
       public override void SomeSharedOverrideMethod(T data) { } 
    }
    class B : Origin<int>
    class B<T> : Origin<T>
