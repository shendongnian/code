    public class FilterDateTimeRange {
        public DateTime? from;
        public DateTime? to;
    
        public FilterDateTimeRange(DateTime? fromDT, DateTime? toDT) {
            from = fromDT;
            to = toDT;
        }
    
        public Expression<Func<T, bool>> RangeFilter<T>(Expression<Func<T, DateTime?>> memberFn) {
            Expression<Func<DateTime?, bool>> rangeBodyTemplate;
            if (from.HasValue) {
                if (to.HasValue)
                    rangeBodyTemplate = dt => from <= dt && dt <= to;
                else
                    rangeBodyTemplate = dt => from.Value <= dt;
            }
            else if (to.HasValue) {
                rangeBodyTemplate = dt => dt <= to.Value;
            }
            else
                rangeBodyTemplate = dt => true;
    
            return Expression.Lambda<Func<T, bool>>(rangeBodyTemplate.Body.Replace(rangeBodyTemplate.Parameters[0], memberFn.Body), memberFn.Parameters);
        }
    }
    
    public static class FilterExt {
        public static IQueryable<T> WhereInRange<T>(this IQueryable<T> src, FilterDateTimeRange r, Expression<Func<T, DateTime?>> memberFn) => src.Where(r.RangeFilter(memberFn));
    }
