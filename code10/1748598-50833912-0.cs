	public interface IEntity { }
	public interface IRepositoryDal<T> where T : IEntity { }
	public interface IDbManager { }
	
	public class User : IEntity { }
	
	public class UserBal //busines logic
	{
		[Injectivity.Attributes.Inject]
	    private IRepositoryDal<User> _userRepositoryDal;
	}
	
	public class UserRepositoryDal: IRepositoryDal<User>
	{
		[Injectivity.Attributes.Inject]
	    private IDbManager _dbManager;
	}
	
	public class DbManager : IDbManager
	{
		[Injectivity.Attributes.Construct()]
		public DbManager([Injectivity.Attributes.Key("dbKey", typeof(string))] string x)
		{
			Console.WriteLine($"DbManager created with parameter \"{x}\"");
		}
	}
