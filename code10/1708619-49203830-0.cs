	var autoMapperConfig = new AutoMapper.MapperConfiguration(cfg =>
	{
		cfg.CreateMap<ContactInfo1, ContactInfo2>()
			.ForMember(dest => dest.AnotherName, opt => opt.MapFrom(src => src.Name))
			.ReverseMap();
		cfg.CreateMap<Person, ContactInfo2>()
			.ConstructUsing((p, ctx) => ctx.Mapper.Map<ContactInfo2>(p.Contact));
	});
