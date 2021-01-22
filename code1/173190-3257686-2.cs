        private static IKernel kernel = new StandardKernel();
        protected void Application_Start()
        {
            kernel.Bind<IRepository<User>>().To<NHibernateRepository<User>>();
            ControllerBuilder.Current.SetControllerFactory( new NinjectControllerFactory( kernel ) );
        }
