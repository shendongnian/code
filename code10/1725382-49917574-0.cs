    public interface IMyFactory
    {
        IMyInterface Create();
    }
    
    public class MyFactory : IMyFactory
    {
        public IMyInterface Create()
        {
            // Complex logic here to determine what i would like to give back
            return new MyImplementation();
        }
    }
