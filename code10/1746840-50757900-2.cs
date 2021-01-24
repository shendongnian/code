	public class SmsService
	{
		private readonly IServiceScopeFactory _scopeFactory;
	
		public SmsService(IServiceScopeFactory scopeFactory)
		{
			_scopeFactory = scopeFactory;
		}
	
		public async Task SaveMessage(....)
		{
			using (var scope = _scopeFactory.CreateScope())
			{
				using (var ctx = scope.ServiceProvider.GetService<MyDbContext>())
				{
					... make changes
					await ctx.SaveChangesAsync();
				}
			}
		}
	}
