    CreateMap<TSource, TDestination>()
      .ForMember(dst => dst.Prop1, src => src.MapFrom(p => p.Prop1))
      .AfterMap((s, d) => 
       { 
            if (d.Prop2 == null) d.Prop2 = new AutoConstructedList<TSomeModel>();
    
            d.Prop2 .Add(new TSomeModelDto 
            {
               PropX = s.TSomeModelDto.PropX
            });
       }
