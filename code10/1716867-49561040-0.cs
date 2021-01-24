    public void Configure(IApplicationBuilder app)
    {
        app.UseSignalR(routes =>
		{
            routes.MapHub<YourHub>("/yourhub");
        }
     }
