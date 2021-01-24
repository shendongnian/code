    public interface IRepository<T> where T: struct
    {
        Entity<T> GetEntityById(int id);
        ...
    }
