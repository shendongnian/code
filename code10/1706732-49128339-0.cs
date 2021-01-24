    public class ObjectContainer
    {
        private readonly List<object> _instantiatedObjects = new List<object>();
        public void Add(object instantiatedObject)
        {
            _instantiatedObjects.Add(instantiatedObject);
        }
        public IEnumerable<object> GetInstantiatedObjects()
        {
            return _instantiatedObjects;
        }
        public IEnumerable<T> GetInstantiatedObjects<T>()
        {
            return GetInstantiatedObjects().OfType<T>();
        }
    }
    public class InstantiatedObjectsStrategy : BuilderStrategy
    {
        private readonly ObjectContainer _objectContainer;
        public InstantiatedObjectsStrategy(ObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }
        public override void PostBuildUp(IBuilderContext context)
        {
            _objectContainer.Add(context.Existing);
        }
    }
    public class InstantiatedObjectsExtension : UnityContainerExtension
    {
        private readonly ObjectContainer _objectContainer = new ObjectContainer();
        protected override void Initialize()
        {
            Context.Container.RegisterInstance(_objectContainer);
            Context.Strategies.Add(new InstantiatedObjectsStrategy(_objectContainer),
                UnityBuildStage.PostInitialization);
        }
    }
