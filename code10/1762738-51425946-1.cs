     public class QueryColumnMapper<T> 
    {
        public QueryColumnMapper()
        {
            Mappings = new Dictionary<string, Expression<Func<T, object>>>();
        }
        public Dictionary<string, Expression<Func<T, object>>> Mappings { get; set; }
        public Dictionary<string, Expression<Func<T, object>>> GenerateMappings()
        {
            foreach (var item in typeof(T).GetProperties())
            {
                var name = Char.ToLowerInvariant(item.Name[0]) + item.Name.Substring(1); //camel-case name
                // add to mapper object
                Mappings.Add(name, GetExpression(item.Name));
            }
            return Mappings;
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
