    // in the assembly defining the interfaces shared between your modules
    public class ModulesInitialized : PubSubEvent {}
    
    // in the bootstrapper.InitializeModules
    Container.Resolve<IEventAggregator>().GetEvent<ModulesInitialized>().Publish();
    // in the module defining viewA
    _eventAggregator.GetEvent<ModulesInitialized>().Subscribe( () => _regionManager.Requestnavigate( "MyRegion", "ViewA" ), true );
