    public class ServiceModule : NinjectModule
        {
            private string connection;
            public ServiceModule(string connection)
            {
                this.connection = connection;
            }
    
            public override void Load()
            {
                Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connection);
                Bind<IStudentService>().To<StudentService>();
            }
        }
