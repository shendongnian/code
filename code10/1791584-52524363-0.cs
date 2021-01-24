    public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Country, CountryModel>();
                cfg.CreateMap<CountryModel, Country>();.ForMember(x => x.City, opt => opt.Ignore());
            });
        }
