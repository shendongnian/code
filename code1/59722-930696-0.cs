        static void Main()
        {
            var data = (new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }).AsQueryable();
            var predicates = new List<Expression<Func<int, bool>>>();
            predicates.Add(i => i % 3 == 0);
            predicates.Add(i => i >= 8);           
            foreach (var item in data.WhereAny(predicates.ToArray()))
            {
                Console.WriteLine(item);
            }
        }
        public static IQueryable<T> WhereAny<T>(
            this IQueryable<T> source,
            params Expression<Func<T,bool>>[] predicates)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicates == null) throw new ArgumentNullException("predicates");
            if (predicates.Length == 0) return source.Where(x => false); // no matches!
            if (predicates.Length == 1) return source.Where(predicates[0]); // simple
            var param = Expression.Parameter(typeof(T), "x");
            Expression body = Expression.Invoke(predicates[0], param);
            for (int i = 1; i < predicates.Length; i++)
            {
                body = Expression.OrElse(body, Expression.Invoke(predicates[i], param));
            }
            var lambda = Expression.Lambda<Func<T, bool>>(body, param);
            return source.Where(lambda);
        }
