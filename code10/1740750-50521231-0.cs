     public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IUnitOfWork unitOfWork)
        {
          
          
            app.UseHangfireDashboard();
            app.UseHangfireServer();
          
            RecurringJob.AddOrUpdate(() => new Job(unitOfWork).Print(), Cron.MinuteInterval(1));
            app.UseFileServer();
           
}
