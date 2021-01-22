    public class BaseReturnType
    {
    }
    public class DerivedReturnType : BaseReturnType
    {
    }
    
    public abstract class BaseClass<T> where T : BaseReturnType
    {
        public abstract T PolymorphicMethod();
    
    }
    
    public class DerviedClass : BaseClass<DerivedReturnType>
    {
        public override DerivedReturnType PolymorphicMethod()
        {
            throw new NotImplementedException();
        }
    }
