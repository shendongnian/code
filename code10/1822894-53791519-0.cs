    Mapper.Initialize(config =>
    {
        config.CreateMap<User, UserDto>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Key.Id))
            .ForMember(
                dest => dest.DomainIds,
                opt => opt.MapFrom(src => src.Details.Domains));
    });
    var user = new User
    {
        FirstName = "foo",
        Key = new UserKey { Id = Guid.NewGuid() },
        Details = new UserDetails
        {
            Domains = new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
        },
    };
    
    var result = Mapper.Map<UserDto>(user);
