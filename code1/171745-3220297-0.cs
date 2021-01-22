    public interface IHideable
    {
      string State { get; }
      string Hidden { get; }
    }
    ...
    namespace Database
    {
      public partial class Product : IHideable { }
      public partial class Customer : IHideable { }
    }
    ...
    protected IQueryable<T> GetActive<T>(ObjectSet<T> entities)
        where T : IHideable
    {
      var allowedStates = new string[] { "Active" , "Pending" };    
      return (    
        from obj in entities
        where allowedStates.Contains(obj.State)
            && obj.Hidden == "No"
        select obj
      );
    }  
