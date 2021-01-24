      Mapper.Initialize(cfg =>
      {
        cfg.CreateMap<TestClass, TestClassModel>()
          .ForMember(d => d._F1, s => s.MapFrom(o => o.F1));
        cfg.CreateMap<KeyValuePair<string, TestClass>, KeyValuePair<string, TestClassModel>>()
          .ConstructUsing(x => new KeyValuePair<string, TestClassModel>(x.Key, Mapper.Map<TestClassModel>(x.Value)));
        cfg.CreateMap(typeof(Dictionary<,>), typeof(Dictionary<string, TestClassModel>))
          //.ForCtorParam("collection", opt => opt.MapFrom(src => Mapper.Map<IEnumerable<KeyValuePair<string, TestClassModel>>>(src)))
          //.ForCtorParam("comparer", opt => opt.MapFrom(src => StringComparer.OrdinalIgnoreCase));
          .ConstructUsing(src => new Dictionary<string, TestClassModel>(Mapper.Map<IEnumerable<KeyValuePair<string, TestClassModel>>>(src), StringComparer.OrdinalIgnoreCase));
      });
