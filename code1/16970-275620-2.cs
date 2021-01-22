    public static class EnumerableExtensions
    {
        [Pure]
        public static U MapReduce<T, U>(this IEnumerable<T> enumerable, Func<T, U> map, Func<U, U, U> reduce)
        {
            CodeContract.RequiresAlways(enumerable != null);
            CodeContract.RequiresAlways(enumerable.Skip(1).Any());
            CodeContract.RequiresAlways(map != null);
            CodeContract.RequiresAlways(reduce != null);
            return enumerable.AsParallel().Select(map).Aggregate(reduce);
        }
        [Pure]
        public static U MapReduce<T, U>(this IList<T> list, Func<T, U> map, Func<U, U, U> reduce)
        {
            CodeContract.RequiresAlways(list != null);
            CodeContract.RequiresAlways(list.Count >= 2);
            CodeContract.RequiresAlways(map != null);
            CodeContract.RequiresAlways(reduce != null);
            U result = map(list[0]);
            for (int i = 1; i < list.Count; i++)
            {
                result = reduce(result,map(list[i]));
            }
            return result;
        }
        //Parallel version; creates garbage
        [Pure]
        public static U MapReduce<T, U>(this IList<T> list, Func<T, U> map, Func<U, U, U> reduce)
        {
            CodeContract.RequiresAlways(list != null);
            CodeContract.RequiresAlways(list.Skip(1).Any());
            CodeContract.RequiresAlways(map != null);
            CodeContract.RequiresAlways(reduce != null);
    
            U[] mapped = new U[list.Count];
            Parallel.For(0, mapped.Length, i =>
                {
                    mapped[i] = map(list[i]);
                });
            U result = mapped[0];
            for (int i = 1; i < list.Count; i++)
            {
                result = reduce(result, mapped[i]);
            }
            return result;
        }
    
    }
