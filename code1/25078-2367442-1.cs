      _container
                    .Using<IConventionExtension>()
                    .Configure(x =>
                        {
                            x.Conventions.Add(new ClosingTypeConvention(typeof (IRepository<>)));
                            x.Assemblies.Add(Assembly.GetExecutingAssembly());
                        })
                    .Register();
