     class Program
        {
            static void Main(string[] args)
            {
                Mapper.Initialize(configuration =>
                    configuration.CreateMap<Dto, Entity>()
                        .ForMember(x => x.Name, e => e.MapFrom(d => d.MyName))
                        .LimitStrings());
    
                var dto = new Dto() { MyName = "asadasdfasfdaasfasdfaasfasfd12" };
                var entity = Mapper.Map<Entity>(dto);
            }
        }
    
        public static class Extensions
        {
            public static IMappingExpression<TSource, TDestination> LimitStrings<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
            {
                var sourceType = typeof(TSource);
                var destinationType = typeof(TDestination);
    
                TypeMap existingMaps = Mapper.GetAllTypeMaps().First(b => b.SourceType == sourceType && b.DestinationType == destinationType);
                
                var destinationProperties = destinationType.GetProperties();
                foreach (var propertyMap in existingMaps.GetPropertyMaps())
                {
                    foreach (var propertyInfo in destinationProperties)
                    {
                        var attr = propertyInfo.GetCustomAttribute<MaxLengthAttribute>();
                        if (attr != null && propertyInfo.PropertyType == typeof(string))
                        {
                            expression.ForMember(propertyMap.DestinationProperty.Name, opt => opt.ResolveUsing(new StringLimiter(attr.Length, (PropertyInfo)propertyMap.SourceMember)));
                        }
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
                this.propertyMapSourceMember = propertyMapSourceMember;
            }
    
            public ResolutionResult Resolve(ResolutionResult source)
            {
                var sourceValue = (string)propertyMapSourceMember.GetValue(source.Context.SourceValue);
                var result = new string(sourceValue.Take(length).ToArray());
                return source.New(result);
            }
        }
