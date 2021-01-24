    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(configuration =>
                configuration.CreateMap<Dto, Entity>()
                    .ForMember(x => x.Name, e => e.ResolveUsing((dto, entity, value, context) =>
                    {
                        var result = entity.GetType().GetProperty(nameof(Entity.Name)).GetCustomAttribute<MaxLengthAttribute>();
                        return dto.MyName.Substring(0, result.Length);
                    })));
            var myDto = new Dto { MyName = "asadasdfasfdaasfasdfaasfasfd12" };
            var myEntity = Mapper.Map<Dto, Entity>(myDto);
        }
    }
    public class Entity
    {
        [MaxLength(10)]
        public string Name { get; set; }
    }
    public class Dto
    {
        public string MyName { get; set; }
    }
