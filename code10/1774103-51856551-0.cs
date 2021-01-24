	public static class EntityFrameworkExtensions
	{
		public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> source, Expression<Func<T, TProperty>> path)
			where T : class
		{
			#if NETCOREAPP2_0
			return Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.Include(source, path);
			#else
			return System.Data.Entity.DbExtensions.Include(source, path);
			#endif
		}
	}
