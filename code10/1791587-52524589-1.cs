	public class AutoMapperConfiguration
	{
		public static MapperConfiguration Configure()
		{
			var mapper = new MapperConfiguration(cfg =>
				{
					cfg.CreateMap<Country, CountryModel>();
					cfg.CreateMap<CountryModel, Country>().ForMember(x => x.City, opt => opt.Ignore());
				}
			);
			return mapper;
		}
	}
