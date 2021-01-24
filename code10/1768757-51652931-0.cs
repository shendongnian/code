    class MyModule : IModule
    {
        public void Initialize()
        {
            _container.RegisterType<IMyService, DisposeMe>( new ContainerControlledLifetimeManager() );
            _container.RegisterType<IMyOtherService, DisposeMeToo>( new ContainerControlledLifetimeManager() );
            _container.RegisterType<IModuleCleanUp, CleanUpMyModule>( nameof( MyModule ) );
        }
        private class CleanUpMyModule : IModuleCleanUp
        {
            void Finalize()
            {
                _container.Resolve<IMyService>().Dispose();            
                _container.Resolve<IMyOtherService>().Dispose();            
            }
        }
    }
