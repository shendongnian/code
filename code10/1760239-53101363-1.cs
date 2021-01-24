    	app.UseRequestLocalization(options);
		app.UseStatusCodePages(async context =>
		{
			var newPath = new PathString(
					  string.Format(CultureInfo.InvariantCulture, "/{1}/Error/{0}", context.HttpContext.Response.StatusCode, System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName));
			//var formatedQueryString = queryFormat == null ? null :
			//	 string.Format(CultureInfo.InvariantCulture, queryFormat, context.HttpContext.Response.StatusCode);
			//var newQueryString = queryFormat == null ? QueryString.Empty : new QueryString(formatedQueryString);
			var newQueryString = QueryString.Empty;
			var originalPath = context.HttpContext.Request.Path;
			var originalQueryString = context.HttpContext.Request.QueryString;
			// Store the original paths so the app can check it.
			context.HttpContext.Features.Set<IStatusCodeReExecuteFeature>(new StatusCodeReExecuteFeature()
			{
				OriginalPathBase = context.HttpContext.Request.PathBase.Value,
				OriginalPath = originalPath.Value,
				OriginalQueryString = originalQueryString.HasValue ? originalQueryString.Value : null,
			});
			context.HttpContext.Request.Path = newPath;
			context.HttpContext.Request.QueryString = newQueryString;
			try
			{
				await context.Next(context.HttpContext);
			}
			finally
			{
				context.HttpContext.Request.QueryString = originalQueryString;
				context.HttpContext.Request.Path = originalPath;
				context.HttpContext.Features.Set<IStatusCodeReExecuteFeature>(null);
			}
		});
