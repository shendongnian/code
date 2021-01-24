    public static class HtmlHelperExtensions
    {
        public static HtmlString ActionLink<TController>(
            this IHtmlHelper htmlHelper , 
            string linkText, 
            string actionName)
          where TController : ControllerBase
        {
            var controllerName = typeof(TController).Name.Replace("Controller", "");
            var method = typeof(TController).GetMethod(actionName);
            var attributeType = typeof(ActionNameAttribute);
            var attribute = method.GetCustomAttributes(attributeType, false);
            var result = attribute.Length == 0
              ? actionName
              : (attribute[0] as ActionNameAttribute).Name;
            return new HtmlString(result);
        }
    }
