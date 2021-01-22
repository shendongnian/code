    using System;
    using Microsoft.Practices.Unity;
    
    namespace Test
    {
        // Unity configuration
        public class ConfigurationExtension : UnityContainerExtension
        {
            protected override void Initialize()
            {
                // Container.RegisterType<IDataService, DataService>(); Use factory instead
                Container.RegisterType<IInjectionFactory<IDataService>, InjectionFactory<IDataService, DataService>>();
            }
        }
    
        #region General utility layer
    
        public interface IInjectionFactory<out T>
            where T : class
        {
            T Create();
        }
    
        public class InjectionFactory<T2, T1> : IInjectionFactory<T2>
            where T1 : T2
            where T2 : class
    
        {
            private readonly IUnityContainer _iocContainer;
    
            public InjectionFactory(IUnityContainer iocContainer)
            {
                _iocContainer = iocContainer;
            }
    
            public T2 Create()
            {
                return _iocContainer.Resolve<T1>();
            }
        }
    
        #endregion
    
        #region data layer
    
        public class DataService : IDataService, IDisposable
        {
            public object LoadData()
            {
                return "Test data";
            }
    
            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    /* Dispose stuff */
                }
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    
        #endregion
    
        #region domain layer
    
        public interface IDataService
        {
            object LoadData();
        }
    
        public class DomainService
        {
            private readonly IInjectionFactory<IDataService> _dataServiceFactory;
    
            public DomainService(IInjectionFactory<IDataService> dataServiceFactory)
            {
                _dataServiceFactory = dataServiceFactory;
            }
    
            public object GetData()
            {
                var dataService = _dataServiceFactory.Create();
                try
                {
                    return dataService.LoadData();
                }
                finally
                {
                    var disposableDataService = dataService as IDisposable;
                    if (disposableDataService != null)
                    {
                        disposableDataService.Dispose();
                    }
                }
            }
        }
    
        #endregion
    }
