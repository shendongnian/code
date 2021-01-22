    IQueryable<T> IS3Repository.FindAllBuckets<T>()
    {
        IQueryable<T> list = _repository
                             .GetAllBuckets()
                             .Cast<T>()
                             .AsQueryable();
        return list ?? new List<T>().AsQueryable();
    }
