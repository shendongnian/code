    public abstract class Repository<TEntity,TDataContext>
        where TEntity : class
        where TDataContext : DataContext, new() {}
    public abstract class BusinessObject<TEntity,TDataContext,TRepository>
        where TEntity : class
        where TDataContext : DataContext, new()
        where TRepository : Repository<TEntity,TDataContext>
    {
        TRepository _repository;
    }
    public class ConcreteObject : BusinessObject<LSTableClass,LSDataContext,ConcreteRepo>
    { // ...
