    public interface BaseInterface<T> where T: class
    {
        T Method1<U>(U u) where U : T;
    }
    public class DerivedClass : BaseInterface<string>
    {
        string BaseInterface<string>.Method1<U>(U u)
        {
            return "Some String";
        }
    }
