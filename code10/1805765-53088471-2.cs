    public class ValidateModelTransaction : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var json = actionContext.Request.Content.ReadAsStringAsync().Result;
            bool isPositiveAmount = ValidateAmount(json, x => x > 0);
            if (isPositiveAmount)
            {
                // ....
            }
        }
    }
