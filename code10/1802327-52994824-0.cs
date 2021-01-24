    public interface IInteractivityRegistry
    {
        void Add<T>() where T : IInteractivity;
        IReadOnlyList<IInteractivity> ResolveAllInOrder();
    }
    internal class UnityInteractivityRegistry : IInteractivityRegistry
    {
        public UnityInteractivityRegistry(IUnityContainer container)
        {
            _container = container;
        }
        #region IInteractivityRegistry
        public void Add<T>() where T : IInteractivity
        {
            _interactivities.Add( typeof(T) );
        }
        public IReadOnlyList<IInteractivity> ResolveAllInOrder()
        {
            return _interactivities.Select( x => _container.Resolve( x ) ).ToArray();
        }
        #endregion
        #region private
        private readonly List<Type> _interactivities = new List<Type>();
        private readonly IUnityContainer _container;
        #endregion
    }
