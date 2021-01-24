    Mapper.Initialize(cfg => {
      cfg.CreateMap<ModelA, string>().ConvertUsing(new ModelAToStringTypeConverter());
      cfg.CreateMap<ModelA, ModelB>().ConvertUsing(new ModelAToBTypeConverter());
      cfg.CreateMap<ModelB, ModelA>().ConvertUsing(new ModelBToATypeConverter());
      ....
      cfg.AddProfile<WpfProfile>();
    });
    public class WpfProfile: Profile
    {
    	public OrganizationProfile()
    	{
    		CreateMap<Foo, FooDto>();
    		// Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
    	}
    }
