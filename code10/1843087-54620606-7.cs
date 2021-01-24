    public static class UnityConfig {
        public static UnityContainer RegisterComponents() {
            //Unity Configuration
            var container = new UnityContainer();
    
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IHeaderService, HeaderService>();
    
            return container;
        }
    }
