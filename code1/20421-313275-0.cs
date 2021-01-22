    public interface IMyType
    {
        string SayHello();
        string BaseTypeMethodIWantToUse();
    }
    
    public class MyType : MyBaseType, IMyType
    {
        public string SayHello()
        {
            return "Hello!";
        }
    }
    
    public class MyRemoteableType : MarshalByRefObject, IMyType
    {
        private MyType _instance = new MyType();
    
        public string SayHello()
        {
            _instance.SayHello();
        }
    
        public string BaseTypeMethodIWantToUse()
        {
            _instance.BaseTypeMethodIWantToUse();
        }
    }
