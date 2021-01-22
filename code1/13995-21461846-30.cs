	public class DivideByZeroExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			if (actionExecutedContext.Exception is DivideByZeroException)
			{
				actionExecutedContext.Response = new HttpResponseMessage() { 
					Content = new StringContent("An error occured within the application.",
									System.Text.Encoding.UTF8, "text/plain"), 
					StatusCode = System.Net.HttpStatusCode.InternalServerError
					};
			}
		}
	}
