    	using System.Data.SqlClient;
	public interface IParameter<T> where T : IEntity<T>
	{
		void Populate(SqlParameterCollection parameters, T entity);
	}
