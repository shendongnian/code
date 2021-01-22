    class UnitOfWork : IUnitOfWork
    {
      private readonly IUnityContainer container;
      private ObjectContext objectContext;
    
      public UnitOfWork (IUnityContainer container)
      {
        this.container = container.CreateChildContainer();
      }
    
      public void SetupObjectContext()
      {
        this.objectContext = ... // Create object context here
        this.container.RegisterInstance(context.GetType(), context);
      }
    
      public void Create<TRepository>()
      {
        // As long as we registered created object context instance in child container
        // it will be available now to repositories during resolve
        return this.container.Resolve<TRepository>();
      }
    
      public void Commit()
      {
         this.objectContext.SaveChanges();
      }
    }
    class Repository : IRepository
    {
      private readonly SomeObjectContext objectContext;
    
      public Repository(SomeObjectContext objectContext)
      {
        this.objectContext = objectContext;
      }
    
      public void DoSomethingInDataSource()
      {
        // You can use object context instance here to do the work
      }
    }
