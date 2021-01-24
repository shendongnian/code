    public override void PreInitialize()
    {
        Configuration.Modules.AbpAutoMapper().Configurators.Add(CreateMappings);
    }
    private void CreateCoreMappings(IMapperConfigurationExpression configuration)
    {
         var localizationContext = IocManager.Resolve<ILocalizationContext>();
         configuration.CreateMap<Edition, EditionDto>().ForMember(dest => dest.DisplayName, options => options.MapFrom(src => localizationContext.LocalizationManager.GetString("localizationFileName", src.DisplayName)))
    }
