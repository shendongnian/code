    public class UserProfileMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ProfileBase, UserProfileModel>()
                  .ForAllMembers(m => m.ResolveUsing<ProfileValueResolver>());
        }
        public class ProfileValueResolver : IValueResolver
        {
            public ResolutionResult Resolve(ResolutionResult source)
            {
                return source.New(
                    ((ProfileBase)source.Value)
                    .GetPropertyValue(source.Context.MemberName)
                );
            }
        }
    }
