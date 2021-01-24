    public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
    {
      using(var scope = AutofacHostFactory.Container.BeginLifetimeScope())
      {
        var svc = scope.Resolve<IErrorService>();
        svc.Log(error);
      } 
    }
