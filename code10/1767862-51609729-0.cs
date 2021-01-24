    public class MapperConfig
    {
        public static MapperConfiguration MapperCfg { get; private set; }
        public static IMapper Mapper { get; private set; }
        public static void RegisterMappings()
        {
            MapperCfg = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
                #region Entity VMs
                cfg.CreateMap<Address, AddressVM>().MaxDepth(3).ReverseMap();
                cfg.CreateMap<ApplicationUserConfig, ApplicationUserConfigVM>().MaxDepth(3).ReverseMap();
                // ... You need to define the objects in the mapper config
                cfg.CreateMap<WarehouseConfig, WarehouseConfigVM>().MaxDepth(3).ReverseMap();
                #endregion
            });
            Mapper = MapperCfg.CreateMapper();
        }
    }
