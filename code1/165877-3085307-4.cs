    // Added another interface - GetInstance
    public interface IManager
    {
        object GetObject(int i);
    }
    // made BaseManager abstract; you don't have to do that, but then
    // remember to make everything virtual, etc etc.
    public abstract class BaseManager : IManager
    {
        public abstract object GetObject(int i);
    }
