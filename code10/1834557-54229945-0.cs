    using AutoMapper;
    using AutoMapper.EquivalencyExpression;
    [....]
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddAutoMapper(cfg => {
                    cfg.AddCollectionMappers();
                    });
            }
    [....]
