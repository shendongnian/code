    abstract class Integer
    {
        public abstract int Get { get; }
    }
    
    public class One : Integer { public override int Get { return 1; } } }
    public class Two : Integer { public override int Get { return 2; } } }
    public class Three : Integer { public override int Get { return 3; } } }
    
    public class FixedStorage<T, N> where N : Integer, new()
    {
        T[] storage;
        public FixedStorage()
        {
            storage = new T[new N().Get];
        }
        public T Get(int i)
        {
            return storage[i];
        }
    }
