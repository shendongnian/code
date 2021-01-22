    string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyContextWrapper"].ConnectionString;
    ObjectFactory.Initialize(x =>
                {
                    x.Scan(scan =>
                            {
                                // Make sure BUSINESS_DOMAIN assembly is scanned
                                scan.AssemblyContainingType<BUSINESS_DOMAIN.MyContextWrapper>(); 
                                scan.TheCallingAssembly();
                                scan.WithDefaultConventions();
                            });
                    // 'connStr' below is a local variable defined above
                    x.For<System.Data.Objects.ObjectContext>()
                        .Use<MyContextWrapper>()
                        .Ctor<string>().Is(connStr);
                    x.For<System.Web.Mvc.IController>().Use<Controllers.FooBarController>().Named("foobarcontroller"); 
                });
