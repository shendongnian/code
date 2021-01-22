    IQueryable<T> IS3Repository.FindAllBuckets<T>()
    {
        return _repository.GetAllBuckets()
                          .Cast<T>()
                          .AsQueryable();
    }
