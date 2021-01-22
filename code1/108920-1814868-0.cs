    public interface ISome
    {
        void SomeMethod();
    }
 
    public class SomeClass<T>: ISome
    {
        public virtual void SomeMethod(){ }
    }
    public void DoSomethingClienty()
    {
        Factory factory = new Factory();
        ISome someInstance = factory.Create();
        someInstance.SomeMethod();
    }
