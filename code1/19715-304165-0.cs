    public class RepositoryManager<T> : IRepositoryManager<T> where T : Ixyz, new()
    {
        public T GetOrCreate(string id)
        {
            T item = (T)CreateNew(new T(), id);
            return item;
        }
    }
