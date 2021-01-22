                ObjectFactory.Initialize(x=>
                                         {
                                             // Different connection string for each usage
                                             // of the RelationalGateway class
                                             x.ForRequestedType<RelationalGateway>()
                                                 .AddInstances(r =>
                                                     r.ConstructedBy(() => 
                                                         new RelationalGateway(ConfigRepository.DataSourceName))
                                                 .WithName("config"))
                                                 .TheDefault.Is.ConstructedBy(
                                                 () => new RelationalGateway(OracleSpatialRepository.DataSourceName));
                                             // Inject the right RelationalGateway
                                             x.ForRequestedType<IConfigRepository>()
                                                 .TheDefault.Is.OfConcreteType<ConfigRepository>()
                                                 .CtorDependency<RelationalGateway>().Is(inst => 
                                                     inst.TheInstanceNamed("config"));
                                             x.ForRequestedType<ISpatialRepository>()
                                                 .TheDefault.Is.OfConcreteType<OracleSpatialRepository>()
                                                 .CtorDependency<RelationalGateway>().IsTheDefault();
                                             
                                             // Other simple types
                                             x.ForRequestedType<IIdGenerator>().TheDefaultIsConcreteType<IdGenerator>();
                                         });
