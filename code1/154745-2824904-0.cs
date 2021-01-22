    public interface IEntity
	{
		int Id { get; set; }
	}
    public interface IRepository<TEntity>
		where TEntity : IEntity
	{
		void Add(TEntity entity);
		List<TEntity> GetAll();
	}
