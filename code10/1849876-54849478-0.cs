    private readonly IServiceScopeFactory serviceScopeFactory;
            public MyRepository(IServiceScopeFactory serviceScopeFactory)
            {
                this.serviceScopeFactory = serviceScopeFactory;
            }
    
            public async Task UpdateAttendance(IEnumerable<MyEvents> events)
            {
                try
                {
                    var tasks = events.Select(async entity =>
                    {
                        await Task.Run(() =>
                        {
                            using (var scope = serviceScopeFactory.CreateScope())
                            {
                                var context = scope.GetRequiredService<YourContextType>();
                                context.Entry(entity).Property(x => x.Attendance).IsModified = true;
                                await Context.SaveChangesAsync();
                            }
                        });
                    });
                    await Task.WhenAll(tasks);
                }
                catch (Exception ex)
                {
                    //You really should not do this, did you have a look to ILogger?
                    //If you only wants to stop when an exception gets thrown you can configure VS to do that, Debug menu -> Windows -> Exception Settings
                    throw new Exception(ex.Message ?? ex.InnerException.Message);
                }
            }
