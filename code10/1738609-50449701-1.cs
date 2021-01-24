	public static IQueryable<EntityWithCount<T>> GetWithTotal<T>(this IQueryable<T> entities, int page, int pageSize) where T : class
	{
		return entities
			.Select(e => new EntityWithCount<T> { Entity = e, Count = entities.Count() })
			.Skip((page-1) * pageSize)
            .Take(pageSize);
	}
    public class EntityWithCount<T> where T : class
	{
		public T Entity { get; set; }
		public int Count { get; set; }
	}
