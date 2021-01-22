            builder.RegisterAdapter<ISessionFactory, ISession>(factory => factory.OpenSession())
                .InstancePerHttpRequest()
                .OnActivated(activatedArgs =>
                             {
                                 var session = activatedArgs.Instance;
                                 session.EnableFilter(MyCustomFilter.Name);
                                 session.BeginTransaction();
                             });
