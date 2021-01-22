        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
  
     // Be aware of the order on which the assemblies are added to the AggregateCatalog.
     // It's important to add the assembly to the AggregateCatalog in the correct order, otherwise
     // you may get the error "No valid exports were found that match the constraint".
     // In the example below, if Module B invokes a method of Module C, module C must be
     // added to the AggregateCatalog prior to Module B. 
     // Please note the Bootstrapper assembly also needs to be added to the AggregateCatalog.
     // -------------------------------------------------------------------------------------- 
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleA).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleC).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleB).Assembly));
            
        }
