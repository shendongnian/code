    var container = new WindsorContainer();
    container.Register(Castle.MicroKernel.Registration.Component.For<AuthorizedUserData>().LifestyleSingleton());
    container.Register(
                   Castle.MicroKernel.Registration
                   .Classes
                   .FromAssemblyInThisApplication()
                   .BasedOn<IUserData>()
                   .WithServiceAllInterfaces().Configure(
                       x => x.Interceptors<AuthorizedUserData>()));
              
