	namespace System.Web.Http.Filters
	{
		public interface IExceptionFilter : IFilter
		{
			// Executes an asynchronous exception filter.
			// Returns: An asynchronous exception filter.
			Task ExecuteExceptionFilterAsync(
						HttpActionExecutedContext actionExecutedContext, 
						CancellationToken cancellationToken);
		}
	}
