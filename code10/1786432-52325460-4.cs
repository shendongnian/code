     public static class MappingConfig
        {
            public static MapperConfiguration Configure()
            {
                MapperConfiguration config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<OrderProfile>();
                });
    
                return config;
            }
        }
