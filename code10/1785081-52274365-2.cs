    public interface IBaseInterface
    {
        IBaseInterface ChainableMethod();
    }
   
    public abstract class AbstractClassThatHelps<T>:IBaseInterface where T : IBaseInterface{
        public T ChainableMethod()
        {
            IBaseInterface i = this;
            return (T)i.ChainableMethod();
        }
    
        IBaseInterface IBaseInterface.ChainableMethod()
        {
           return this;
        }
     }
    
    public class Concrete : AbstractClassThatHelps<Concrete>
    {
    }
