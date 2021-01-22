	public class CustomErrorsTransferModule : IHttpModule
	{
		public void Init(HttpApplication context)
		{
			context.Error += Application_Error;
		}
		public void Dispose()  {  }
		private void Application_Error(object sender, EventArgs e)
		{
			var error = Server.GetLastError();
			var httpException = error as HttpException;
			if (httpException == null)
				return;
			var section = ConfigurationManager.GetSection("system.web/customErrors") as CustomErrorsSection;
			if (section == null)
				return;
			if (!AreCustomErrorsEnabledForCurrentRequest(section))
				return;
			var statusCode = httpException.GetHttpCode();
			var customError = section.Errors[statusCode.ToString()];
			Response.Clear();
			Response.StatusCode = statusCode;
			if (customError != null)
				Server.Transfer(customError.Redirect);
			else if (!string.IsNullOrEmpty(section.DefaultRedirect))
				Server.Transfer(section.DefaultRedirect);
		}
		private bool AreCustomErrorsEnabledForCurrentRequest(CustomErrorsSection section)
		{
			return section.Mode == CustomErrorsMode.On ||
				   (section.Mode == CustomErrorsMode.RemoteOnly && !Context.Request.IsLocal);
		}
		private HttpResponse Response
		{
			get { return Context.Response; }
		}
		private HttpServerUtility Server
		{
			get { return Context.Server; }
		}
		private HttpContext Context
		{
			get { return HttpContext.Current; }
		}
	}
