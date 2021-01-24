	public class LogDbCommandInterceptor : IDbCommandInterceptor
	{
		public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
		{
			interceptionContext.SetUserState("start", DateTime.Now);
		}
		public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
		{
			Console.WriteLine($"sql command: {command.CommandText}, hasFailed: {HasFailed(interceptionContext)}, duration: {CalculateDuration(interceptionContext)}");
			Console.WriteLine($"parameters: {FormatParams(command.Parameters)}, exception: {interceptionContext.Exception?.Message}");
		}
	
		public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
		{
			interceptionContext.SetUserState("start", DateTime.Now);
		}
		public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
		{
			Console.WriteLine($"sql command: {command.CommandText}, hasFailed: {HasFailed(interceptionContext)}, duration: {CalculateDuration(interceptionContext)}");
		}
	
		public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
		{
			interceptionContext.SetUserState("start", DateTime.Now);
		}
		public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
		{
			Console.WriteLine($"sql command: {command.CommandText}, hasFailed: {HasFailed(interceptionContext)}, duration: {CalculateDuration(interceptionContext)}");
		}
	    private static double CalculateDuration<T>(DbCommandInterceptionContext<T> context)
		{
			return (DateTime.Now - (DateTime)context.FindUserState("start")).TotalMilliseconds;
		}
	
		private static bool HasFailed<T>(DbCommandInterceptionContext<T> context)
		{
			return context.OriginalException != null || (context.IsAsync && context.TaskStatus != TaskStatus.RanToCompletion);
		}
	
		private static string FormatParams(ICollection dbParameterCollection)
		{
			if (dbParameterCollection.Count == 0)
				return string.Empty;
	
			var parameterDescriptor = new StringBuilder();
	
			foreach (SqlParameter parameter in dbParameterCollection)
			{
				parameterDescriptor.AppendFormat("{0} {1}: {2}, ", parameter.DbType, parameter.ParameterName, parameter.Value);
			}
	
			return parameterDescriptor.ToString().TrimEnd(' ', ',');
		}
	}
