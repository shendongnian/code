    public interface IA<T> where T: class
    {
        void DoIt(T ignore = null);
    }
    public interface IB : IA<IB>
    {
    }
    public interface IC : IA<IC>
    {
    }
