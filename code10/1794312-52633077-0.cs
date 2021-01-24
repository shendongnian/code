    public class Middleware
	{
		private readonly RequestDelegate _next;
		private IServiceProvider _serviceProvider;
		public Middleware(RequestDelegate next, IServiceProvider serviceProvider)
		{
			_next = next;
			_serviceProvider = serviceProvider;
		}
		public Task Invoke(HttpContext context)
		{
			var factory = _serviceProvider.GetService<IServiceScopeFactory>();
			using (var scope = factory.CreateScope())
			{
				context.RequestServices = scope.ServiceProvider;
	            // Do whatever you want here and return a task
			}
		}
	}
