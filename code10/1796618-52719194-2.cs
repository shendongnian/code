    cfg.CreateMap<Address, AddressDto>();
    cfg.CreateMap<AddressExtended, AddressExtendedDto>();
    cfg.CreateMap<IAddress, IAddressDto>().ConstructUsing((addressDto, ctx) =>
    {
        var destination = Mapper.Instance.ConfigurationProvider.GetAllTypeMaps()
                            .First(t => t.SourceType == addressDto.GetType());
        return ctx.Mapper.Map(addressDto, addressDto.GetType(), destination.DestinationType) as IAddressDto;
    });
