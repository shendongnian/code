    public class ValidateModelFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ModelState.IsValid) {  return; }
            // There are model errors
            // iterate through each item in ModelState and 
            // pull out the errors/messages and present them however you like.
            // I'd use some kind of dedicated ErrorResult object
            actionContext.Result = new BadRequestObjectResult(yourErrorResultObject)
        }
    }
