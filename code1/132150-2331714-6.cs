    Mapper.CreateMap<DomainObjects.Members.IMemberRegistration,
        DTO.Members.MemberRegistrationForm>()
            .ForMember(src => src.StatusMessages,
                opt => opt
                    .ResolveUsing<BrokenRulesCollectionResolver>()
                    .FromMember(r => r.BrokenRules));
