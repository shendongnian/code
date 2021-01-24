      internal class ServiceScope : IServiceScope, IDisposable
      {
        private readonly Microsoft.Extensions.DependencyInjection.ServiceProvider _scopedProvider;
    
        public ServiceScope(Microsoft.Extensions.DependencyInjection.ServiceProvider scopedProvider)
        {
          this._scopedProvider = scopedProvider;
        }
    
        public IServiceProvider ServiceProvider
        {
          get
          {
            return (IServiceProvider) this._scopedProvider;
          }
        }
    
        public void Dispose()
        {
          this._scopedProvider.Dispose();
        }
      }
