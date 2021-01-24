        // create
        // ent => exp(ent).Contains(s)
        public static IQueryable<T> WhereContains<T>(this IQueryable<T> qry, Expression<Func<T, string>> exp, string s)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                s = s.Trim();
                //HERE GRAB THE PARAMETER
                var param = exp.Parameters[0];
                //HERE JUST USE EXP.BODY
                var body = Expression.Call(exp.Body, typeof(string).GetMethod("Contains", new[] { typeof(string) }), Expression.Constant(s));
                var lambda = Expression.Lambda<Func<T, bool>>(body, param);
                qry = qry.Where(lambda);
            }
            return qry;
        }
