    public abstract class Manager<T> : IManager<T> {
      protected IRepository<T> Repository { get; set; }
      // ...
      public virtual List<T> GetAll() {
        return Repository.GetAll();
      }
    }
