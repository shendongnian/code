    public static class DynamicExtentions
    {
        public static IEnumerable<T> DynamicOrder<T>(this IEnumerable<T> data, string[] orderings) where T : class
        {
            var orderedData = data.OrderBy(x => x.GetPropertyDynamic(orderings.First()));
            foreach (var nextOrder in orderings.Skip(1))
            {
                orderedData = orderedData.ThenBy(x => x.GetPropertyDynamic(nextOrder));
            }
            return orderedData;
        }
        public static object GetPropertyDynamic<Tobj>(this Tobj self, string propertyName) where Tobj : class
        {
            var param = Expression.Parameter(typeof(Tobj), "value");
            var getter = Expression.Property(param, propertyName);
            var boxer = Expression.TypeAs(getter, typeof(object));
            var getPropValue = Expression.Lambda<Func<Tobj, object>>(boxer, param).Compile();            
            return getPropValue(self);
        }
    }
