    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(m =>
            {
                m.CreateMap<ClassOne, ClassOne>().ForMember(d => d.ClassTwoExample.ClassThreeExample, s => s.Ignore())
                                                 .ForMember(d => d.ClassTwoExample.ClassFourExample, s => s.Ignore());
            });
        }
    }
