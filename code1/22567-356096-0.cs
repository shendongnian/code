    public class ChildContainer2 : IChildContainer
    {
        private IUnityContainer _container;
    
        public ChildContainer(IUnityContainer parent)
        {
            _container = parent.CreateChildContainer();
        }
        public IUnityContainer Container { get { return _container; } }
    }
