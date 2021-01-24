    public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
    {
      //log the error using the service
      var svc = AutofacHostFactory.Container.Resolve<IErrorService>();
      svc.Log(error); 
    }
