    IMapper _mapper;
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Source, Destination>();
    });
    _mapper = config.CreateMapper();
    Source src = new Source
    {
    //initialize properties
    }
    Destination dest = new dest
    {
    //initialize properties
    }
    _mapper.Map(src, dest);
