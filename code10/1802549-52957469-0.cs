    public static IEnumerable<T> Filter<T>(this IEnumerable<T> results, Filter filter)
        {
            var types = results.GetType().GetProperties();
            
            foreach (var filter in filter.Filters)
            {
                Type type = results.GetType();
                filter.ColumnName = filter.ColumnName.Replace(" ", "");
                var pred = BuildPredicate<T>(filter.ColumnName, filter.FilterValue);
                if (filter.ColumnName != null && filter.FilterValue != null)
                {
                    results = results.Where(w =>
                    {                        
                        return w.GetType().GetProperty(filter.ColumnName).GetValue(w, null).ToString().ToLowerInvariant().Contains(filter.FilterValue.ToLowerInvariant());
                    });
                }
            }
            return results;
        }
