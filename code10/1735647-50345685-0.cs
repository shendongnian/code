    MappingConfig.CreateMap<MyDbModel1, MyViewModel1>()
        .ForMember(vm => vm.ValueName, o => o.MapFrom(ent => ent.SomeValue))
        .ForMember(vm => vm.NestedModel1, o => o.MapFrom(ent => ent.OtherTableModel1));
    MappingConfig.CreateMap<OtherTableModel1, NestedModel1>()
        .ForMember(vm => vm.SomeValue1 , o => o.MapFrom(ent => ent.Value1))
        .ForMember(vm => vm.SomeValue2 , o => o.MapFrom(ent => ent.Value2));
    var items = Mapper.Map<MyViewModel1[]>(MyDbContext.MyDbModel1.Where(dbm1 => dbm1.SomeValue > 10));
