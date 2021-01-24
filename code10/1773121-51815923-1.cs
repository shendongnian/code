    public class UnityPageResolver
    {
        private IUnityContainer unityContainer;
        public UnityPageResolver(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }
        public T ResolvePage<T>()
            where T : Page // do we need this restriction here?
        {
            return unityContainer.Resolve<T>();
        }
    }
