    public abstract class ReadOnlyRepository<T,V>
    {
         V Find(T lookupKey);
    }
    public abstract class InsertRepository<T>
    {
         void Add(T entityToSave);
    }
    public abstract class UpdateRepository<T,V>
    {
         V Update(T entityToUpdate);
    }
    public abstract class DeleteRepository<T>
    {
         void Delete(T entityToDelete);
    }
