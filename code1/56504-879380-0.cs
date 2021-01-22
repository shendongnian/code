    IWindsorContainer _ConfiguredContainer = null;
    public IWindsorContainer GetContainer()
    {
       if (LoggedIn == false)
          throw new InvalidOperationException("Cannot be called before a user logs in");
       
       if (_ConfiguredContainer == null)
       {
          _ConfiguredContainer = new WindsorContainer(new XmlInterpreter());
          
          // Do your 'extra' config here.
          _ConfiguredContainer.AddComponentWithProperties(/*blah blah blah*/);
       }
       
       return _ConfiguredContainer;
    } 
