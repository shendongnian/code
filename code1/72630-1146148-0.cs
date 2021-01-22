    public interface IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> List();
        TEntity Get(int id);
    }
    
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> List()
        {
            //DataContext.GetTable<TEntity>().ToList();
        }
        TEntity Get(int id)
        {
            //Might have to do some magic here... you can use reflection or create
            //an abstract method that the derived class must override that returns
            //a delegate id selector.
        }
    }
