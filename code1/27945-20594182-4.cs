    public class MultipleButtonsEnumAttribute : ActionFilterAttribute
    {
        public Type EnumType { get; set; }
        public MultipleButtonsEnumAttribute(Type enumType)
        {
            EnumType = enumType;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            foreach (var key in filterContext.HttpContext.Request.Form.AllKeys)
            {
                if (Enum.IsDefined(EnumType, key))
                {
                    var pDesc = filterContext.ActionDescriptor.GetParameters()
                        .FirstOrDefault(x => x.ParameterType == EnumType);
                    filterContext.ActionParameters[pDesc.ParameterName] = Enum.Parse(EnumType, key);
                    break;
                }
            }
        }
    }
