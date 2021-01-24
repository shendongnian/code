public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new ValidationFailedResult(context.ModelState);
        }
    }
}
And then is added like so: 
[Route("api/values")]
[ValidateModel]
public class ValuesController : Controller
{
...
}
Or you can control the response generation by overriding the `InvalidModelStateResponseFactory`, like in this SO question: https://stackoverflow.com/questions/51145243/how-do-i-customize-asp-net-core-model-binding-errors
Here is an example: 
services.Configure<ApiBehaviorOptions>(o =>
{
    o.InvalidModelStateResponseFactory = actionContext =>
        new MyCustomBadRequestObjectResult(actionContext.ModelState);
});
