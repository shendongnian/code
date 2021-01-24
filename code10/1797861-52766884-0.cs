    container.Register(Component.For(typeof(IHelloService<>))
        .ImplementedBy(typeof(HelloService<>), new Only<IProduct>())
        .LifestyleTransient());
    public class Only<T> : IGenericServiceStrategy
    {
        public bool Supports(Type service, ComponentModel component) => typeof(T).IsAssignableFrom(service.GetGenericArguments()[0]);
    }
