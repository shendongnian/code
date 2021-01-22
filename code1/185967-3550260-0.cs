    // add new() to your where clause:
    public class CacheCollection<T> : List<CacheItem<T>> where T : EntityBase, new()
    // change the creation of the object:
    ...
    T entity = new T();
    entity.Id = Id;
    ...
