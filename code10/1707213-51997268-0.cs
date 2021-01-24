    app.UseExceptionHandler(new ExceptionHandlerOptions
    {
      ExceptionHandler = async context =>
	  {
		 var exception = context.Features.Get<IExceptionHandlerFeature>().Error;
		 if (!context.Request.Path.StartsWithSegments(new PathString("/api"), StringComparison.OrdinalIgnoreCase))
		 {
			context.Response.Redirect("Error");
		 }
		 else
		 {
			context.Response.ContentType = "application/json";
			var response = new
			{
				Error = exception.Message
			};
			await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
		 }
	   }
    });
