    public void MappingTests()
    {
        dynamic sourceModel = new ExpandoObject();
        // flat model - id should map to TargetModel, Address01 will map to a nested type Address on TargetModel
        sourceModel.Id = 1;
        sourceModel.Address01 = "address01";
        Mapper.Initialize(cfg =>
        {
            cfg.CreateMap<ExpandoObject, TargetModel>()
            .ForMember(dest => dest.AbstractAddress, opt => opt.MapFrom(src => new Address() { Address01 = src.First(kvp => kvp.Key == "Address01").Value.ToString() }))
            .ForMember(destinationMember => destinationMember.Id, opt => opt.MapFrom(src => src.First(kvp => kvp.Key == "Id").Value));
        });
        TargetModel target = Mapper.Map<TargetModel>(sourceModel);
    }
