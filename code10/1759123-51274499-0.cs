    public class FactoryFallbackExtension : UnityContainerExtension
    {
        public FactoryFallbackExtension()
        {
        }
        protected override void Initialize()
        {
            var strategy = new FallBackStrategy(Context);
            Context.Strategies.Add(strategy, UnityBuildStage.PreCreation);
        }
    }
    public class FallBackStrategy : BuilderStrategy
    {
        private ExtensionContext baseContext;
        public FallBackStrategy(ExtensionContext baseContext)
        {
            this.baseContext = baseContext;
        }
        public override void PreBuildUp(IBuilderContext context)
        {
            var key = context.OriginalBuildKey;
            if (key.Type.IsInterface)
            {
                if(GlobalContext.InstanceFactory.CanGetInstance(key.Type))
                    context.Existing = GlobalContext.InstanceFactory.GetInstance(key.Type);    
            }
        }
    }
