     private void CreateMaps()
        {
            CreateMap<ContactEntity, TransfereeEntityDto>();
            
            //ContactEntity Mapping
            CreateMap<ContactEntity, TransfereeEntityDto>();
            //CustomerEntity Mapping
            CreateMap<CustomerEntity, CustomerEntityDto>();
            //AddressEntity Mapping
            CreateMap<AddressEntity, AddressEntityDto>();
            //ServiceEntity Mapping
            CreateMap<ServiceEntity, ServiceEntityDto>()
              .ForMember(dto => dto.ServiceTypeCode, opt => opt.MapFrom(source => source.TypeCode))
              .ForMember(dto => dto.ServiceDescriptionCode, opt => opt.MapFrom(source => source.DescriptionCode))
              .ForMember(dest => dest.SourceSystemName, opt => opt.ResolveUsing<SourceSystemNameResolver>().FromMember(entity => entity.SourceSystemName));
            //VehicleEntity Mapping
            CreateMap<VehicleEntity, VehicleEntityDto>()
                .ForMember(dest => dest.SourceSystemName, opt => opt.ResolveUsing<SourceSystemNameResolver>().FromMember(entity => entity.SourceSystemName))
                .ForMember(dto => dto.PortalId, option => option.Ignore());  //TODO: Should PortalID be mapped to anything? It is not in the entity.
            //ContentEntity Mapping
            CreateMap<ContentEntity, ContentEntityDto>()
                .ForMember(dest => dest.SourceSystemName, opt => opt.ResolveUsing<SourceSystemNameResolver>().FromMember(entity => entity.SourceSystemName));
            //OrderForwardingEntity Mapping
            CreateMap<OrderForwardingEntity, OrderForwardingEntityDto>();
            //ContainerEntity Mapping
            CreateMap<ContainerEntity, ContainerEntityDto>()
                .ForMember(dest => dest.SourceSystemName, opt => opt.ResolveUsing<SourceSystemNameResolver>().FromMember(entity => entity.SourceSystemName));
            //ShipmentForwardingEntity Mapping
            CreateMap<ShipmentForwardingEntity, ShipmentForwardingEntityDto>();
            //ShipmentRouting Mapping
            CreateMap<ShipmentRoutingEntity, ShipmentRoutingEntityDto>();
            //ShipmentEntity Mapping
            CreateMap<ShipmentEntity, ShipmentEntityDto>()
                .ForMember(dest => dest.SourceSystemName, opt => opt.ResolveUsing<SourceSystemNameResolver>().FromMember(entity => entity.SourceSystemName))
                .ForMember(dto => dto.Services, option => option.MapFrom(source => source.ServiceEntities));
            //Forwarder mapping
            CreateMap<ContactEntity, ForwarderEntityDto>();
            //TODO: This property doesn't have any properties in the data contract
            //OrderEntity Mapping
            CreateMap<OrderEntity, OrderEntityDto>()
                .ForMember(dest => dest.SourceSystemName,
                           opt => opt.ResolveUsing<SourceSystemNameResolver>().FromMember(entity => entity.SourceSystemName));
                //.ForMember(dto => dto.Forwarder, option => option.MapFrom(entity=>entity.Forwarder)
            //MoveEntityMapping
            CreateMap<MoveEntity, MoveEntityDto>()
                .ForMember(dto => dto.SourceSystemName, opt => opt.ResolveUsing<SourceSystemNameResolver>().FromMember(entity => entity.SourceSystemName));
        }
