       public interface IRepository<T> where T : class
       {
            T GetById(int id);
            void Add(T entity);
       }
