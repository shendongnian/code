    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
	{
		app.UseForwardedHeaders();
		app.Use(async (context, next) =>
		{
			if (context.Request.IsHttps || context.Request.Headers["X-Forwarded-Proto"] == Uri.UriSchemeHttps)
			{
				await next();
			}
			else
			{
				string queryString = context.Request.QueryString.HasValue ? context.Request.QueryString.Value : string.Empty;
				var https = "https://" + context.Request.Host + context.Request.Path + queryString;
				context.Response.Redirect(https);
			}
		});
		if (env.IsDevelopment())
		{
			// code removed for clarity
		}
		else
		{
			// code removed for clarity
			app.UseHsts();
		}
		app.UseHttpsRedirection();
        // code removed for clarity
		app.UseMvc();
	}
