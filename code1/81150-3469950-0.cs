    public class UserRepository : BaseRepository<User>, IUserRepository
    {
    	protected BaseRepository(IUnitOfWork unitOfWork)
    	{
    	}
    	
    	...
    }
