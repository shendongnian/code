    public static WindsorContainer Container = null;
            
       public static void WireUp()
       {
                        Container = new WindsorContainer();
                        Container.Register(Component.For<GlobalERPEntities>());
                        Container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>());
                        Container.Register(Component.For<IService_HR_Person>().ImplementedBy<Service_HR_Person>());
       }
