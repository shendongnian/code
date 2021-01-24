        public class QueryColumnMapper<T> : Dictionary<string, Expression<Func<T, object>>>
    {
        public QueryColumnMapper<T> GenerateMappings()
        {
            foreach (var item in typeof(T).GetProperties())
            {
                // get dictionary key ======> its OK
                var name = Char.ToLowerInvariant(item.Name[0]) + item.Name.Substring(1); //camel-case name
                // add to mapper object
                this.Add(name, GetExpression(item.Name));
            }
            return this;
        }
        private Expression<Func<T,object>> GetExpression(string propertyName)
        {
                       // x =>
            var parameter = Expression.Parameter(typeof(T));
            // x.Name
            var mapProperty = Expression.Property(parameter, propertyName);
            // (object)x.Name
            var convertedExpression = Expression.Convert(mapProperty, typeof(object));
            // x => (object)x.Name
            return Expression.Lambda<Func<T, object>>(convertedExpression, parameter);
        }
    }
