	public class TaskRepository //: IRepository<Task>
	{
		SqlDatabaseThing db;
		public TaskRepository(SqlDatabaseThing db)
		{
			this.db = db;
		}
	
		readonly string GetByIdCommand = "select id, userid, name from tasks where id = @id";
		readonly string GetByIdCommandParameterId = "@id"
		readonly SqlDbType GetByIdCommandParameterIdType = SqlDbType.BigInt;
		public Task GetById(long id)
		{
			var command = new SqlCommand(GetByIdCommand);
			var parameters = IEnumerableHelper.ToEnumerable<SqlParameter>(new SqlParameter(GetByIdCommandIdParameter, GetByIdCommandIdParameterType, id));
			var dataTable = db.ExecuteToDataTable(command, parameters);
			return DataTableToTask(dataTable)[0];
		}
		private IEnumerable<Task> DataTableToTask(DataTable dt)
		{
			foreach (var row in dt.Rows)
			{
				yield return DataRowToTask(row);
			}
		}
		private Task DataRowToTask (DataRow dr)
		{
			return new Task()
			{
				Id = dr["Id"]
				,Name = dr["Name"]
				,UserId = dr["UserId"]
			};
		}
		
	}
	
	public static class IEnumerableHelper
	{
		public static IEnumerable<T> ToEnumerable<T>(params T[] parameters)
		{
		    return parameters;
		} 
	}
