    public static PaginatedList<T> Paginate<T>(this IQueryOver<T, T> instance, int page, int pageSize) where T : Entity {
        var countCriteria = instance.ToRowCountQuery();
        var totalCount = countCriteria.FutureValue<int>();
    
        var items = instance.Take(pageSize).Skip((page- 1)*pageSize).List<T>();
        return new PaginatedList<T>(items, page, pageSize, totalCount.Value);
    }
