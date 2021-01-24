    var container = new UnityContainer();
    var phone = "214-123-4567";
    container.RegisterType<FaxServiceFactory>();
    container.RegisterType<IFaxProvider, EFaxProvider>();
    container.RegisterInstance<IFaxService>(container.Resolve<FaxServiceFactory>().Create(phone));
    var fax = container.Resolve<IFaxService>();
