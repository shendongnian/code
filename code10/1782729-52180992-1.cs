    public class MyFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                //store request in data base
                context.Result = new BadRequestObjectResult(new MyErrorModel() { ID = "1", FriendlyMessage = "Your request was invalid" });
            }
        }
    }
