    public static class Components
    {
        public static void Config() {
            TypeAdapterConfig.GlobalSettings.AllowImplicitDestinationInheritance = true;
            var registers = new List<IRegister>();
            registers.Add(new DtoMapping());
            registers.Add(new MappingRegistration());
            TypeAdapterConfig.GlobalSettings.Apply(registers);
    
            ObjectMapper.Current = new MapsterAdapter();
            DbConfiguration.Loaded += DbConfiguration_Loaded;
    
            var r = new Registrations();
            r.Run();
        }
    
    
        private static void DbConfiguration_Loaded(object sender, System.Data.Entity.Infrastructure.DependencyResolution.DbConfigurationLoadedEventArgs e)
        {
            e.ReplaceService<DbProviderServices>((s, k) => System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }
    
    }
