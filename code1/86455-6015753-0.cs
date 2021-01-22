    public class FactoryUnityExtension : UnityContainerExtension
    {
        private ICustomFactory factory;
        private CustomFactoryBuildStrategy strategy;
        public FactoryUnityExtension(ICustomFactory factory)
        {
            this.factory = factory;
        }
        protected override void Initialize()
        {
            this.strategy = new CustomFactoryBuildStrategy(factory, Context);
            Context.Strategies.Add(strategy, UnityBuildStage.PreCreation);
            Context.Policies.Set<ParentMarkerPolicy>(new ParentMarkerPolicy(Context.Lifetime), new NamedTypeBuildKey<ParentMarkerPolicy>());
        }
    }
    public class ParentMarkerPolicy : IBuilderPolicy
    {
        private ILifetimeContainer lifetime;
        public ParentMarkerPolicy(ILifetimeContainer lifetime)
        {
            this.lifetime = lifetime;
        }
        public void AddToLifetime(object o)
        {
            lifetime.Add(o);
        }
    }
    public interface ICustomFactory
    {
        object Create(Type t);
        bool CanCreate(Type t);
    }
    public class CustomFactoryBuildStrategy : BuilderStrategy
    {
        private ExtensionContext baseContext;
        private ICustomFactory factory;
        public CustomFactoryBuildStrategy(ICustomFactory factory, ExtensionContext baseContext)
        {
            this.factory = factory;
            this.baseContext = baseContext;
        }
        public override void PreBuildUp(IBuilderContext context)
        {
            var key = (NamedTypeBuildKey)context.OriginalBuildKey;
            if (factory.CanCreate(key.Type) && context.Existing == null)
            {
                context.Existing = factory.Create(key.Type);
                var ltm = new ContainerControlledLifetimeManager();
                ltm.SetValue(context.Existing);
                // Find the container to add this to
                IPolicyList parentPolicies;
                var parentMarker = context.Policies.Get<ParentMarkerPolicy>(new NamedTypeBuildKey<ParentMarkerPolicy>(), out parentPolicies);
                // TODO: add error check - if policy is missing, extension is misconfigured
                // Add lifetime manager to container
                parentPolicies.Set<ILifetimePolicy>(ltm, new NamedTypeBuildKey(key.Type));
                // And add to LifetimeContainer so it gets disposed
                parentMarker.AddToLifetime(ltm);
                // Short circuit the rest of the chain, object's already created
                context.BuildComplete = true;
            }
        }
    }
