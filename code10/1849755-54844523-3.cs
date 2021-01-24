    public static class DynamicFilterExtensionMethods
    {
        public static IEnumerable<T> FilterByQueryParams<T>(this IEnumerable<T> collection, IQueryCollection queryParams) where T : new()
        {
            var classType = typeof(T);
            var propList = classType.GetProperties();
            //accountNumber ==> accountNumber, AccountNumber ==> accountNumber
            var props = new Dictionary<string, PropertyInfo>(propList.Select(x => new KeyValuePair<string, PropertyInfo>(Char.ToLowerInvariant(x.Name[0]) + x.Name.Substring(1), x)));
            foreach (var param in queryParams) {
                if (props.ContainsKey(param.Key)) {
                    var prop = props[param.Key];
                    if ( param.Value.Count == 1 && prop.PropertyType.IsPrimitive) {
                        collection = collection.Where(x => prop.GetValue(x, null).ToString() == param.Value.First());                        
                    }
                }
            }
            return collection;
        }
    }
