    public class ValidateActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as EmployeesController ; 
            if (controller == null)
            {
                throw new InvalidOperationException("It is not EmployeesController !!!");
            }
     
            var propVal= controller.PropertyName;  
        }
    }
