     public static HtmlHelperExtensions
     {
       public static MvcHtmlString ActionLink<TController>(this HtmlHelper htmlHelper
         , string linkText, string actionName)
         where TController : ControllerBase
       {
         var controllerName = typeof(TController).Name.Replace("Controller", "");
         var method = typeof(TController).GetMethod(actionName);
         var attributeType = typeof(ActionNameAttribute);
         var attribute = method.GetCustomAttributes(attributeType, false);
         result = attribute.Length == 0
           ? actionName
           : (attribute[0] as ActionNameAttribute).Name
         return result;
     }
