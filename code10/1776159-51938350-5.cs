    public static class HtmlHelperExtensions
    {
        public static IHtmlContent ActionLink<TController>(
            this IHtmlHelper htmlHelper, 
            string linkText, 
            string actionName)
          where TController : ControllerBase
        {
            var suffix = nameof(Controller);
            var controllerName = typeof(TController).Name.Replace(suffix, "");
            var method = typeof(TController).GetMethod(actionName);
            var attributeType = typeof(ActionNameAttribute);
            var attribute = method.GetCustomAttributes(attributeType, false);
            actionName = attribute.Length == 0
              ? actionName
              : (attribute[0] as ActionNameAttribute).Name;
            return htmlHelper.ActionLink(linkText, actionName);
        }
    }
