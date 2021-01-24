    public interface IFilterRange<TMember> {
        Expression<Func<TData, bool>> RangeFilter<TData>(Expression<Func<TData, TMember>> memberFn);
    }
    
    public class FilterDateTimeRange : IFilterRange<DateTime?> {
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
                    rangeBodyTemplate = dt => from.Value <= dt && dt <= to.Value;
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
    
    public class FilterDateRange : IFilterRange<DateTime?> {
        public DateTime? from;
        public DateTime? to;
    
        public FilterDateRange(DateTime? fromDT, DateTime? toDT) {
            from = fromDT?.Date;
            to = toDT?.Date;
        }
    
        public Expression<Func<T, bool>> RangeFilter<T>(Expression<Func<T, DateTime?>> memberFn) {
            Expression<Func<DateTime?, bool>> rangeBodyTemplate;
            if (from.HasValue) {
                if (to.HasValue)
                    rangeBodyTemplate = dt => from <= (dt == null ? dt : dt.Value.Date) && (dt == null ? dt : dt.Value.Date) <= to;
                else
                    rangeBodyTemplate = dt => from.Value <= (dt == null ? dt : dt.Value.Date);
            }
            else if (to.HasValue) {
                rangeBodyTemplate = dt => (dt == null ? dt : dt.Value.Date) <= to.Value;
            }
            else
                rangeBodyTemplate = dt => true;
    
            return Expression.Lambda<Func<T, bool>>(rangeBodyTemplate.Body.Replace(rangeBodyTemplate.Parameters[0], memberFn.Body), memberFn.Parameters);
        }
    }
    
    public static class FilterExt {
        public static IQueryable<TData> WhereInRange<TData, TMember>(this IQueryable<TData> src, IFilterRange<TMember> r, Expression<Func<TData, TMember>> memberFn) => src.Where(r.RangeFilter(memberFn));
    }
