    public static class Filtering
    {
        public class WhereParams
        {
            public string ColumnName { get; set; }
            public object Value { get; set; }
            public string Operator { get; set; }
            public string AndOr { get; set; }
        }
        /// <summary>
        /// Make a predicate from the specified <paramref name="wheres"/>.
        /// </summary>
        public static Expression<Func<T, bool>> ToPredciate<T>(this IEnumerable<WhereParams> wheres)
        {
            using (var e = wheres.GetEnumerator())
            {
                if (!e.MoveNext()) // not filtered
                    return x => true;
                var pe = Expression.Parameter(typeof(T), "x");
                var body = GetComparePredicateBody(pe, e.Current); // first condition
                // join body with more conditions
                while (e.MoveNext())
                {
                    var right = GetComparePredicateBody(pe, e.Current);
                    switch (e.Current.AndOr)
                    {
                        case "AND":
                            body = Expression.AndAlso(body, right);
                            break;
                        case "OR":
                            body = Expression.OrElse(body, right);
                            break;
                        default:
                            // LessThan and Equal don't make much sense on booleans, do they?
                            throw new Exception("Bad boolean operator.");
                    }
                }
                return Expression.Lambda<Func<T, bool>>(body, pe);
            }
        }
        /// <summary>
        /// Returns a boolean expression x.ColumnName op Value.
        /// </summary>
        private static Expression GetComparePredicateBody(Expression x, WhereParams where)
        {
            var left = Expression.Property(x, where.ColumnName);
            var right = Expression.Constant(where.Value);
            switch (where.Operator)
            {
                case "Equals": return Expression.Equal(left, right);
                case "LESS THAN": return Expression.LessThan(left, right);
                // ...
                default: throw new ArgumentException("Bad comparison operator.");
            }
        }
        public static IQueryable<T> Where<T>(this IQueryable<T> source, IEnumerable<WhereParams> wheres) => source.Where(wheres.ToPredciate<T>());
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, IEnumerable<WhereParams> wheres) => source.Where(wheres.ToPredciate<T>().Compile());
    }
