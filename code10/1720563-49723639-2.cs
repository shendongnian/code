    private static Func<Employee, dynamic> GetSortable(string sortablePoperty)
        {
            var param = Expression.Parameter(typeof(Employee), "e");
            var member = Expression.Property(param, sortablePoperty);
            Expression memberAsObject = Expression.Convert(member, typeof(object));
            return Expression.Lambda<Func<Employee, dynamic>>(memberAsObject, param).Compile();
        }
