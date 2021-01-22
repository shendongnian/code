    public class WindsorControllerFactory : IControllerFactor
    {
      IWindsorContainer container;
      public WindsorControllerFactory()
      {
        container =
          new WindsorContainer(
            new XmlInterpreter(
              new ConfigResource("castleWindsor")
          ));
          
        container.Register(
          AllTypes.Of<IController>()
          .FromAssembly(Assembly.GetExecutingAssembly())
          .Configure(component => component.LifeStyle.Transient
            .Named(component.Implementation.Name)
          ));
      }
    }
      
    
