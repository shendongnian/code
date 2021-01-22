    public interface IEntity<TListItemType>
    {
         // stuff snipped
    
         IQueryable<TListItemType> GetAll();
    }
    public class Dealer : IEntity<Dealer>
    {
       public IQueryable<Dealer> GetAll() { // some impl here }
    }
