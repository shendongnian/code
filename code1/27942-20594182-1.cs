    public class MultipleButtonsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Type tButtonType = typeof(ButtonType);
            foreach (var key in filterContext.HttpContext.Request.Form.AllKeys)
            {
                if (Enum.IsDefined(tButtonType, key))
                {
                    var pDesc = filterContext.ActionDescriptor.GetParameters()
                        .FirstOrDefault(x => x.ParameterType == tButtonType);
                    filterContext.ActionParameters[pDesc.ParameterName] = Enum.Parse(tButtonType, key);
                    
                }
            }
        }
    }
