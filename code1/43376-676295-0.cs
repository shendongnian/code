    public interface IEntity<T>
    {
        IQueryable<T> GetAll();
    }
    
    public class Dealer : IEntity<Dealer>
    {
       public IQueryable<Dealer> GetAll() { }
    }
