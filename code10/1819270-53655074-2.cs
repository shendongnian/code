    public class CustomClass { }
    
    public interface IConn
    {
        CustomClass CC();
    }
    
    public class Conn : IConn
    {
        // this will always return a new instance of CustomClass, which is
        // not the same behaviour as the code in your attempt.
        public CustomClass CC() {
            return new CustomClass();
        }
    }
