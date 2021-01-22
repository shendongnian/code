    public interface IRepositorySource<T>
    {
        IRepository<T> GetNew();
    }
    public class RepositorySource : IRepositorySource<ISomeEntity>, IRepositorySource<ISomeOtherEntity>
    {
    	IRepository<ISomeEntity> IRepositorySource<ISomeEntity>.GetNew()
    	{
    		...
    	}
    
    	IRepository<ISomeOtherEntity> IRepositorySource<ISomeOtherEntity>.GetNew()
    	{
    		...
    	}
    }
