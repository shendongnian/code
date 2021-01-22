    interface IMyTable<T>
    {
      Table<T> TheTable {get;}
    }
    
    public class MyClass<TContext,T> where
      TContext : DataContext,IMyTable<T>
    {
      //silly implementation provided to support the later example:
      public TContext Source {get;set;}
    
      public List<T> GetThem()
      {
        IMyTable<T> x = Source as IMyTable<T>;
        return x.TheTable.ToList(); 
      }
    }
