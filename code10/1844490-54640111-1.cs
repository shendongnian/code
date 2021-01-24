    public class MySite : IServiceProvider, ISite
    {
        public IComponent Component => null;
        public IContainer Container => null;
        public bool DesignMode => true;
        public string Name { get => ""; set => value = ""; }
        public object GetService(Type serviceType)
        {
            return null;
        }
    }
