    public interface IRepository<T> where T : PersistentObject
    {
        T Get(int id);        
        void Save(T e);
        void Delete(T e);
    }
