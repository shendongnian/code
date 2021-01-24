    public class ProvidersManager<TProvider> where TProvider : IProviderInterface
    {
        public ProvidersManager() =>
           ProviderObj = Activator.CreateInstance<TProvider>();
    }
    // eg: new ProvidersManager<ProviderA>();
