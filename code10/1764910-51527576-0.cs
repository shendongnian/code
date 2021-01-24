        return queryable.SelectAsync(x => x);
    }
    
    public static IEnumerable<TResult> SelectAsync<T, TResult>(this IQueryable<T> queryable, Function<T, TResult> selector)
    {
        var dataServiceQuery = queryable as DataServiceQuery<T>;
        return Task.Run(async () => (await (new TaskFactory<IEnumerable<T>>()).FromAsync(dataServiceQuery.BeginExecute, dataServiceQuery. EndExecute, null)).Select(selector)).Result;
    }
