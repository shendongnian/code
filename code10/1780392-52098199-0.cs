    public class ProviderFactory
    {
        public ProviderFactory(...) { ... } // Inject all the stuff you need here
        public IProvider CreateProvider(string type)
        {
            // switch on `type`, new up the right provider, and return it
        }
    }
