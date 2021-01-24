	public class YourCustomMiddleware
	{
		private readonly RequestDelegate _next;
		public YourCustomMiddleware(RequestDelegate next)
		{
			_next = next;
		}
		public async Task InvokeAsync(HttpContext httpContext)
		{
			if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
			{
				httpContext.User.Identities.FirstOrDefault().AddClaim(new Claim("your claim", "your field"));
				await _next(httpContext);
			}
		}
	}
