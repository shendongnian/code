    public interface M
    {
    }
    
    public interface N
    {
    }
    
    public interface IWrapS<T> where T : IM
    {
    }
    
    public interface IWrapR<T> where T: IM, IN
    {
    }
    
    public class WrapS<T> where IWrapS<T>
    {
    }
    public class WrapR<T> where IWrapR<T>
    {
    }
