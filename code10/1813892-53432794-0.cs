    public class ReverseMappingProfile : Profile
    {
        public ReverseMappingProfile()
        {
            RecognizeDestinationPrefixes("Billing", "Mailing");
            CreateMap<Model, ViewModel>()
                .ReverseMap();
            CreateMap<Address, ViewModel>()
                .ReverseMap();
        }
    }
