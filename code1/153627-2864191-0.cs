    class Repository : IRepository {
      readonly string m_ConnectionString;
      public Repository(string connectionString) {
        ConnectionString = connectionString;
      }
    }
    
    //When registering
    container.RegisterType<IRepository, Repository>(new InjectionConstructor("connectionstring"));
