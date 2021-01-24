    [Produces("application/json")]
    [GenericControllerNameConvention]
    [EnableQuery]
    public class GenericSubNavigationController<TBaseType, TSubType, TSubTypeDeclared> : GenericControllerBase<TBaseType>
    {
        public GenericSubNavigationController(ISubTypeEnricher subTypeEnricher) : base(subTypeEnricher)
        {
        }
        public async Task<IQueryable<TSubTypeDeclared>> GetNavigation([FromServices] ODataQueryOptions odataQueryOptions, Guid key)
        {
            PropertyInfo propertyInfo = typeof(TBaseType).GetProperties().FirstOrDefault(x => x.PropertyType == typeof(TSubType));
            string propertyName = propertyInfo.Name;
            var parameters = new Dictionary<string, string>();
            AppendKeyAttributeFilter(parameters, key);
            AppendExpandFilter(parameters, propertyName);
            var subParameters = new Tuple<string, Dictionary<string, string>>(propertyName, ExtractQueryParameter(odataQueryOptions));
            var rootObject = await InternalGet<TBaseType>(parameters, subParameters);
            if (rootObject.Any())
            {
                var info = typeof(TBaseType).GetProperty(propertyName);
                object value = info.GetValue(rootObject.FirstOrDefault());
                return new EnumerableQuery<TSubTypeDeclared>((IEnumerable<TSubTypeDeclared>) value);
            }
            return null;
        }
    }
