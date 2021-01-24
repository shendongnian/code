    public class AutofacEventHandlingBootstrapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventDispatcher>().As<IEventDispatcher>().InstancePerLifetimeScope();
            builder.RegisterType<DomainEventHandlingsExecutor>().As<IDomainEventHandlingsExecutor>().InstancePerLifetimeScope();
    
            RegisterEventHandlersFromDomainModel(builder);
        }
    
        private static void RegisterEventHandlersFromDomainModel(ContainerBuilder builder)
        {
            var domainModelExecutingAssembly = new DomainModelExecutingAssemblyGetter().Get();
    
            builder.RegisterAssemblyTypes(domainModelExecutingAssembly)
                .Where(t => t.GetInterfaces().Any(i => i.IsClosedTypeOf(typeof(IHandler<>))))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
