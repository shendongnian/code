    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Message, MessageViewModel>()
        .ForMember(destination => destination.Subject, map => map.MapFrom(source => source.Subject))
        .ForMember(destination => destination.CreationDate, map => map.MapFrom(source => source.CreationDate))
        .ForMember(destination => destination.Messages , map => map.MapFrom(source => source.Messages));
    });
    Message SourceObject = new Message();
    // Populate with values
    var mapper = config.CreateMapper();
    MessageViewModel DestinationObject = mapper.Map<MessageViewModel>(SourceObject);
