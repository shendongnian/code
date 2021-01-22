    Mapper.CreateMap<DomainObjects.Members.IMemberRegistration,
        DTO.Members.MemberRegistrationForm>()
            .ForMember(src => src.StatusMessages,
                opt => opt
                    .ResolveUsing<BrokenRulesCollectionResolver>()
                    .MapFrom(r => r.BrokenRules));
