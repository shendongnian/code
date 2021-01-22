	namespace System.Web.Http.Filters
	{
		// Represents the attributes for the exception filter.
		[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, 
				Inherited = true, AllowMultiple = true)]
		public abstract class ExceptionFilterAttribute : FilterAttribute, 
				IExceptionFilter, IFilter
		{
			// Raises the exception event.
			// actionExecutedContext: The context for the action.</param>
			public virtual void OnException(
				HttpActionExecutedContext actionExecutedContext)
			{
			}
			// Asynchronously executes the exception filter.
			// Returns: The result of the execution.
			Task IExceptionFilter.ExecuteExceptionFilterAsync(
				HttpActionExecutedContext actionExecutedContext, 
				CancellationToken cancellationToken)
			{
				if (actionExecutedContext == null)
				{
					throw Error.ArgumentNull("actionExecutedContext");
				}
				this.OnException(actionExecutedContext);
				return TaskHelpers.Completed();
			}
		}
	}
