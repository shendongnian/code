    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(configuration =>
                configuration.CreateMap<Dto, Entity>()
                    .ForMember(x => x.Name, e => e.MapFrom(d => d.MyName))
                    .ForMember(x => x.Free, e => e.MapFrom(d => d.Free))
                    .ForMember(x => x.AnotherName, e => e.MapFrom(d => d.Another))
                    .LimitStrings());
            var dto = new Dto() { MyName = "asadasdfasfdaasfasdfaasfasfd12", Free = "ASFÑLASJDFÑALSKDJFÑALSKDJFAMLSDFASDFASFDASFD", Another = "blalbalblalblablalblablalblablalblablabb"};
            var entity = Mapper.Map<Entity>(dto);
        }
    }
    public static class Extensions
    {
        public static IMappingExpression<TSource, TDestination> LimitStrings<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);
            var existingMaps = Mapper.GetAllTypeMaps().First(b => b.SourceType == sourceType && b.DestinationType == destinationType);
            var propertyMaps = existingMaps.GetPropertyMaps().Where(map => ((PropertyInfo)map.SourceMember).PropertyType == typeof(string));
            foreach (var propertyMap in propertyMaps)
            {
                var attr = propertyMap.DestinationProperty.MemberInfo.GetCustomAttribute<MaxLengthAttribute>();
                if (attr != null)
                {
                    expression.ForMember(propertyMap.DestinationProperty.Name,
                        opt => opt.ResolveUsing(new StringLimiter(attr.Length, (PropertyInfo) propertyMap.SourceMember)));
                }                                            
            }
            
            return expression;
        }
    }
    public class StringLimiter : IValueResolver
    {
        private readonly int length;
        private readonly PropertyInfo propertyMapSourceMember;
        public StringLimiter(int length, PropertyInfo propertyMapSourceMember)
        {
            this.length = length;
            this.propertyMapSourceMember = propertyMapSourceMember ?? throw new ArgumentNullException(nameof(propertyMapSourceMember));
        }
        public ResolutionResult Resolve(ResolutionResult source)
        {
            var sourceValue = (string)propertyMapSourceMember.GetValue(source.Context.SourceValue);
            var result = new string(sourceValue.Take(length).ToArray());
            return source.New(result);
        }
    }
