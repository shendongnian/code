            var container = new UnityContainer();
            var phone = "214-123-4567";
            container.RegisterType<IFaxService, FaxService>();
            container.RegisterType<IFaxProvider, EFaxProvider>();
            container.RegisterType<FaxService>(new InjectionConstructor(phone));
            var fax = container.Resolve<IFaxService>();
