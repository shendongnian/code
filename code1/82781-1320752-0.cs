    public class MyRepo<U> : NHRepository<U>, IRepository<U>
    {
    ...
    
    }
    
    public interface IRepository<T> : IRepositoryActionActor<T>
    {
    
    }
    
    public interface IRepositoryActionActor<T>
    {
        T Get(Guid objId);
    }
