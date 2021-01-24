	public static IQueryable<EntityWithCount<T>> GetPageWithTotal<T>(this IQueryable<T> entities, int page, int pageSize) where T : class
	{
		return entities
			.Select(e => new EntityWithCount<T> { Entity = e, Count = entities.Count() })
			.GetPage(page, pageSize);
	}
    public class EntityWithCount<T> where T : class
	{
		public T Entity { get; set; }
		public int Count { get; set; }
	}
