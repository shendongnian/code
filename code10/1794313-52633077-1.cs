    public class Middleware
	{
		private readonly RequestDelegate _next;
		private IServiceScopeFactory _scopeFactory;
		public Middleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
		{
			_next = next;
			_scopeFactory = scopeFactory;
		}
		public async Task Invoke(HttpContext context)
		{
			using (var scope = _scopeFactory.CreateScope())
			{
				context.RequestServices = scope.ServiceProvider;
	            // Do whatever you want here
                if (_next != null)
                    await _next(context);
			}
		}
	}
