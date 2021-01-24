    public class JobServiceProviderActivator : IJobActivator
    {   
        private readonly IServiceProvider provider;
       
        public JobServiceProviderActivator(IServiceProvider provider)
        {
            this.provider = provider;
        }
    
        public T CreateInstance<T>()
        {
            return provider.GetService<T>();
        }
    }
