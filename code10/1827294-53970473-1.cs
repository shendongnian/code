    public class ValidateActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as BaseController ; 
            if (controller == null)
            {
                throw new InvalidOperationException("It is not EmployeesController!");
            } 
            var propVal= controller.PropertyName;  
            //check propVal here
        }
    }
