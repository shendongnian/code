	public class NormalProfile : Profile
	{
		protected override void Configure()
		{
			base.CreateMap<ThingDto, Thing>();
		}
	}
	public class ProfileWithCondition : Profile
	{
		protected override void Configure()
		{
			base.CreateMap<ThingDto, Thing>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
		}
	}
