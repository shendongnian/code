    public interface IPlugin
    {
        void Initialize(IResourceContext context);    
        //Other methods...
    }
    public abstract class Plugin : IPlugin
    {
        protected IResourceContext Context { get; private set; }
        void IPlugin.Initialize(IResourceContext context)
        {
            Context = context;
        }
        //Abstract declaration of other methods...
    }
