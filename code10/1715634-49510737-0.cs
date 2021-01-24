    public sealed class Bootstrapper
    {
      private static StructureMap.Container _container;
    
      public StructureMap.Container MyContainer
      {
        get { return _container; }
      }
      static Bootstrapper() 
      {
      }
    
      public static Initialize()
      {
        StructureMap.Configuration.DSL.Registry registry = new StructureMap.Configuration.DSL.Registry();
        registry.For<IUser>().Use<User>();
        registry.For<IDatabase>().Use<Database>();
        registry.ForConcreteType<UserManagement>().Singleton();
        _container = new Container(registry);
      }
    }
