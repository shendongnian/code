    public class ArrayResolver : ISubDependencyResolver
    {
        private readonly IKernel kernel;
        public ArrayResolver(IKernel kernel)
        {
              this.kernel = kernel;
        }
        public object Resolve(CreationContext context, ISubDependencyResolver parentResolver,
                              ComponentModel model,
                              DependencyModel dependency)
        {
             return kernel.ResolveAll(dependency.TargetType.GetElementType(), null);
        }
        public bool CanResolve(CreationContext context, ISubDependencyResolver parentResolver,
                              ComponentModel model,
                              DependencyModel dependency)
        {
              return dependency.TargetType != null &&
			dependency.TargetType.IsArray &&
			dependency.TargetType.GetElementType().IsInterface;
        }
    }
    public class AnimalManager
    {
         private readonly IAnimal[] _animals;
         public AnimalManager(IAnimal[] animals)
         {
             _animals = animals
         }
    }    
    //Setup container somewhere
    public IWindsorContainer ConfigureContainer()
    {
         IWindsorContainer container = new WindsorContainer().Register(AllTypes.FromAssemblyContaining<Cat>());
         container.Kernel.Resolver.AddSubResolver(typeof(ArrayResolver));
         IAnimalManager manager = container.Resolve<AnimalManager>();
    }
