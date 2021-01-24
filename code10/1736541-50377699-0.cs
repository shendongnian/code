    public abstract class BaseClass<T>
    {
        public abstract void MyMethod(T value);
    }
    
    public class InheritedClass: BaseClass<InheritedClass>
    {
        public override void MyMethod(InheritedClass value)
        {
        }
    }
