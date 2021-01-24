    public partial class App : PrismApplication
    {
		private AbstractLibSerial _lib;
        
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {            
            containerRegistry.RegisterSingleton<IMessageBuilder, MessageBuilderVariant1>();
            containerRegistry.RegisterSingleton<AbstractLibSerial, LibSerialVariant1>();
            containerRegistry.RegisterSingleton(typeof(SettingsModel));
            var _container = containerRegistry.GetContainer();
            _lib = _container.Resolve<LibSerialVariant1>();
            containerRegistry.RegisterInstance<AbstractLibSerial>(_lib);
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);            
            
            moduleCatalog.AddModule(typeof(MainModule.MainModule));
            moduleCatalog.AddModule(typeof(SettingsModule.SettingsModule));            
        }
        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);
            _lib.SerialEvent += ((Shell)shell).OnSerialEvent;
        }
        protected override Window CreateShell()
        {
            return (Window)new Shell();
        }
		
	}
