	public abstract class BaseRepository<TEntity>
	{
		public async Task<ListReturnDTO<TEntity>> QueryDataAsync()
		{
			var items = new ListReturnDTO<TEntity>();
			
			items.QueryStartTime = DateTime.UtcNow;
			
			await QueryAndPopulateDataAsync(items);
			items.QueryEndTime = DateTime.UtcNow;
			return items;
		}
		
		protected abstract Task QueryAndPopulateDataAsync(ListReturnDTO<TEntity> container);
	}
