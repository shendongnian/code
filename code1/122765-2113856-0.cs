    public class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            Container.RegisterType<IProductModule>();
    
            base.ConfigureContainer();
        }
    
        private static ObservableCollection<IProductModule> _productModules = new Obser...();
        public static ObservableCollection<IProductModule> ProductModules
        { 
             get { return _productModules; } 
        }
        protected override IModuleCatalog GetModuleCatalog()
        {
            var modCatalog = new ModuleCatalog()
                .AddModule(typeof(ProductAModule));
            //TODO: add all modules to ProductModules collection
    
            return modCatalog;
        }
    
       ...
    }
