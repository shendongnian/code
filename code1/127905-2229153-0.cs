    public interface IStorage<T>
    {
        void Store(object data);
        void Store<T>(T data);
    }
    
    public class Storage : IStorage<int>
    {
        public void Store(object data)
        {
            Console.WriteLine("Generic");
        }
    
        public void Store(int data)
        {
            Console.WriteLine("Specific");
        }
    }
