    public static IMapper Initialize()
    => new MapperConfiguration(cfg =>
    {
       cfg.CreateMap(typeof(IPaggedResults<>), typeof(PaggedResults<>));
       cfg.MapPaggedResults<CustomerCompany, CustomerDto>();
    }).CreateMapper();
