app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
	{
		var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
		var exception = errorFeature.Error;
		var problemDetails = new ProblemDetails
		{
			Title = R.ErrorUnexpected,
			Status = status,
			Detail =
			  $"{exception.Message} {exception.InnerException?.Message}"
		};
		context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
		context.Response.StatusCode = problemDetails.Status.GetValueOrDefault();
		context.Response.WriteJson(problemDetails, "application/problem+json");
		await Task.CompletedTask;
	});
});
`app.UseExceptionHandler` is a much lower level function than controller actions, and thus do not take part in anything related to CORS natively. Adding `context.Response.Headers.Add("Access-Control-Allow-Origin", "*");` fixed the problem.
