    public interface IInterfaces
    {
        int Open(string stringName);
    }
    
    public class DerivedForInterface1 : IInterfaces
    {
        private IInterface1 _instance;
        public DerivedForInterface1(IInterface1  instance)
        {
            _instance = instance;
        }
    
        public int Open(string stringName) { return _instance.Open(stringName); }
    }
    
    public class DerivedForInterface2 : IInterfaces
    {
        private IInterface2 _instance;
        public DerivedForInterface2(IInterface2  instance)
        {
            _instance = instance;
        }
    
        public int Open(string stringName) { return _instance.Open(stringName); }
    }
