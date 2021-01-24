    class Entity
    {
        public int Key { get; set; }
        public int MyProperty1 { get; set; }
    }
    class Dto
    {
        public dynamic MyKeyProperty { get; set; }
        public int MyProperty1 { get; set; }
    }
    Mapper.Initialize(cfg =>
    {
        cfg.CreateMap<Entity, Dto>()
           .ForMember(nameof(Dto.MyKeyProperty), c => c.Ignore())
           .AfterMap((e, d) => { d.MyKeyProperty = $"{e.Key} ???"; });
    });
