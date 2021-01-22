        static void Main()
        {
            ShowEmps(29); // 4 rows
            ShowEmps(null); // 23 rows
        }
        static void ShowEmps(int? manager)
        {
            using (var ctx = new DataClasses2DataContext())
            {
                ctx.Log = Console.Out;
                var emps = ctx.Employees.Where(x => x.ReportsTo, manager).ToList();
                Console.WriteLine(emps.Count);
            }
        }
        static IQueryable<T> Where<T, TValue>(
            this IQueryable<T> source,
            Expression<Func<T, TValue?>> selector,
            TValue? value) where TValue : struct
        {
            var param = Expression.Parameter(typeof (T), "x");
            var member = Expression.Invoke(selector, param);
            var body = Expression.Equal(
                    member, Expression.Constant(value, typeof (TValue?)));
            var lambda = Expression.Lambda<Func<T,bool>>(body, param);
            return source.Where(lambda);
        }
