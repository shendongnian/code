    public interface IRepository<T> : IQueryable<T>
    {
      void Add(T entity);
      T Get(Guid id);
      void Remove(T entity);
    }
    
    public class Repository<T> : IQueryable<T>
    {
      private readonly ISession session;
    
      public Repository(ISession session)
      {
        session = session;
      }
    
      public Type ElementType
      {
        get { return session.Query<T>().ElementType; }
      }
    
      public Expression Expression
      {
        get { return session.Query<T>().Expression; }
      }
    
      public IQueryProvider Provider
      {
        get { return session.Query<T>().Provider; } 
      }  
    
      public void Add(T entity)
      {
        session.Save(entity);
      }
    
      public T Get(Guid id)
      {
        return session.Get<T>(id);
      }
    
      IEnumerator IEnumerable.GetEnumerator()
      {
        return this.GetEnumerator();
      }
      
      public IEnumerator<T> GetEnumerator()
      {
        return session.Query<T>().GetEnumerator();
      }
     
      public void Remove(T entity)
      {
        session.Delete(entity);
      }   
    }
