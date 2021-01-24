    public interface IFilter<TMember> {
        Expression<Func<TData, bool>> FilterFn<TData>(Expression<Func<TData, TMember>> memberFn);
    }
    
    public class FilterDateTimeRange : IFilter<DateTime?> {
        public DateTime? from;
        public DateTime? to;
    
        public FilterDateTimeRange(DateTime? fromDT, DateTime? toDT) {
            from = fromDT;
            to = toDT;
        }
    
        public Expression<Func<T, bool>> FilterFn<T>(Expression<Func<T, DateTime?>> memberFn) {
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
    
    public class FilterDateRange : IFilter<DateTime?> {
        public DateTime? from;
        public DateTime? to;
    
        public FilterDateRange(DateTime? fromDT, DateTime? toDT) {
            from = fromDT?.Date;
            to = toDT?.Date;
        }
    
        public Expression<Func<T, bool>> FilterFn<T>(Expression<Func<T, DateTime?>> memberFn) {
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
    
    public class FilterStartsWith : IFilter<String> {
        public string start;
    
        public FilterStartsWith(string start) => this.start = start;
    
        public Expression<Func<T, bool>> FilterFn<T>(Expression<Func<T, string>> memberFn) {
            Expression<Func<string, bool>> rangeBodyTemplate;
            if (!String.IsNullOrEmpty(start))
                rangeBodyTemplate = s => s.StartsWith(start);
            else
                rangeBodyTemplate = s => true;
    
            return Expression.Lambda<Func<T, bool>>(rangeBodyTemplate.Body.Replace(rangeBodyTemplate.Parameters[0], memberFn.Body), memberFn.Parameters);
        }
    }
    
    public static class FilterExt {
        public static IQueryable<TData> WhereFilteredBy<TData, TMember>(this IQueryable<TData> src, IFilter<TMember> r, Expression<Func<TData, TMember>> memberFn) => src.Where(r.FilterFn(memberFn));
    }
