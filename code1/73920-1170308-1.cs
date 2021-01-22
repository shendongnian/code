    interface IService
    {
      void Do();
    }
    
    class Service : IService
    {
      private readonly IUnitOfWorkFactory unitOfWorkFactory;
      public Service(IUnitOfWorkFactory unitOfWorkFactory)
      {
        this.unitOfWorkFactory = unitOfWorkFactory;
      }
    
      public void Do()
      {
        // Whenever we need to perform some data manipulation we create and later dispose
        // dispose unit of work abstraction. It is created through a factory to avoid 
        // dependency on particular implementation.
        using(IUnitOfWork unitOfWork = this.unitOfWorkFactory.Create())
        {
           // Unit of work holds Entity Framework ObjectContext and thus it used 
           // create repositories and propagate them this ObjectContext to work with
           IRepository repository = unitOfWork.Create<IRepository>();
           repository.DoSomethingInDataSource();
           // When we are done changes must be commited which basically means committing
           // changes of the underlying object context.
           unitOfWork.Commit();
        }
      }
    }
	/// <summary>
	/// Represents factory of <see cref="IUnitOfWork"/> implementations.
	/// </summary>
	public interface IUnitOfWorkFactory
	{
		/// <summary>
		/// Creates <see cref="IUnitOfWork"/> implementation instance.
		/// </summary>
		/// <returns>Created <see cref="IUnitOfWork"/> instance.</returns>
		IUnitOfWork Create();
	}
	/// <summary>
	/// Maintains a list of objects affected by a business transaction and coordinates the writing out of 
	/// changes and the resolution of concurrency problems.
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Creates and initializes repository of the specified type.
		/// </summary>
		/// <typeparam name="TRepository">Type of repository to create.</typeparam>
		/// <returns>Created instance of the repository.</returns>
		/// <remarks>
		/// Created repositories must not be cached for future use because once this 
		/// <see cref="IUnitOfWork"/> is disposed they won't be able to work properly.
		/// </remarks>
		TRepository Create<TRepository>();
		/// <summary>
		/// Commits changes made to this <see cref="IUnitOfWork"/>.
		/// </summary>
		void Commit();
	}
	/// <summary>
	/// Represents factory of <see cref="UnitOfWork"/>s. 
	/// </summary>
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		private readonly IUnityContainer container;
		/// <summary>
		/// Initializes a new instance of the <see cref="UnitOfWorkFactory"/> class.
		/// </summary>
		/// <param name="container">
		/// Dependency injection container instance used to manage creation of repositories 
		/// and entity translators.
		/// </param>
		public UnitOfWorkFactory(IUnityContainer container)
		{
                     this.conainer = container;
		}
		/// <summary>
		/// Creates <see cref="IUnitOfWork"/> implementation instance.
		/// </summary>
		/// <returns>Created <see cref="IUnitOfWork"/> instance.</returns>
		public IUnitOfWork Create()
		{
			var unitOfWork = this.container.Resolve<UnitOfWork>();
			unitOfWork.SetupObjectContext();
			return unitOfWork;
		}
                  
         ... other members elidged for clarity
	}
