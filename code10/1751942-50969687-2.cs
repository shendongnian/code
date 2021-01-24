    public static class CommonMethods<T> 
    {
        private static readonly MethodInfo orderByMethod =
            typeof(Enumerable).GetMethods().Single(method =>
                method.Name == nameof(Enumerable.OrderBy) && method.GetParameters().Length == 2);
        public static ObservableCollection<T> Sort(ObservableCollection<T> array, string columnName, bool sort) 
        {
            var tType = typeof(T);
            var parameter = Expression.Parameter(tType);
            Expression member = Expression.Property(parameter, columnName);
            var lambda = Expression.Lambda(member, paramter);
            var genericMethod = orderByMethod.MakeGenericMethod(tType, member.Type);
            var orderedData = genericMethod.Invoke(null, new object[] { array, lambda }) as IEnumerable<T>;
            return new ObservableCollection<T>(orderedData);
        }
    }
