    class UnitOfWork : IDisposable
    {
       private readonly DbContext _yourDbContext; 
       
       public UnitOfWork(DbContext yourDbContext)
       {
          _yourDbContext = yourDbContext
       }
       
       public void Save()
       {
    	   _yourDbContext.Save();	   
       }
       
       void Dispose()
       {	   
    	   _yourDbContext = null;   
       }
    }
    public interface IUnitOfWork
    {
    	void Save();	
    }
