    public class BaseToChildMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "BaseToChildMappingProfile"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<BaseClass, ChildClassOne>();
            Mapper.CreateMap<BaseClass, ChildClassTwo>();
        }
    }
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<BaseToChildMappingProfile>();
            });
        }
    }
