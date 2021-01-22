    public class BaseRepository<T> where T : DataContext
    {
       protected T _dc;
    
       public BaseRepository(string connectionString)
       {
          _dc = (T) Activator.CreateInstance(typeof(T), connectionString);
       }
    
       public void SubmitChanges()
       {
          _dc.SubmitChanges();
       }
    }
