    public class MapperProfile : Profile {
        public MapperProfile() {
            CreateMap<SourceInformation, Destination>().ForMember(....);
            CreateMap<SourceInformation, IEnumerable<Destination>>().ConvertUsing<CustomConverter>();
        }
    }
