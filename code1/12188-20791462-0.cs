    public static class MyProjectExtensions
    {
        public static MvcHtmlString ActionLink<TController>(this HtmlHelper htmlHelper, Expression<Action<TController>> expression, string linkText)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection);
            var link = new TagBuilder("a");
            string actionName = ExpressionHelper.GetExpressionText(expression);
            string controllerName = typeof(TController).Name.Replace("Controller", "");
            link.MergeAttribute("href", urlHelper.Action(actionName, controllerName));
            link.SetInnerText(linkText);
            return new MvcHtmlString(link.ToString());
        }
        
        public static MvcHtmlString ActionLink<TController, TAction>(this HtmlHelper htmlHelper, Expression<Action<TController, TAction>> expression, string linkText, object routeValues)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection);
            var link = new TagBuilder("a");
            string actionName = ExpressionHelper.GetExpressionText(expression);
            string controllerName = typeof(TController).Name.Replace("Controller", "");
            link.MergeAttribute("href", urlHelper.Action(actionName, controllerName, routeValues));
            link.SetInnerText(linkText);
            return new MvcHtmlString(link.ToString());
        }
        public static MvcHtmlString ActionLink<TController>(this HtmlHelper htmlHelper, Expression<Action<TController>> expression, string linkText, object routeValues, object htmlAttributes) where TController : Controller
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection);
            var attributes = AnonymousObjectToKeyValue(htmlAttributes);
            var link = new TagBuilder("a");
            string actionName = ExpressionHelper.GetExpressionText(expression);
            string controllerName = typeof(TController).Name.Replace("Controller", "");
            link.MergeAttribute("href", urlHelper.Action(actionName, controllerName, routeValues));
            link.MergeAttributes(attributes, true);
            link.SetInnerText(linkText);
            return new MvcHtmlString(link.ToString());
        }
        private static Dictionary<string, object> AnonymousObjectToKeyValue(object anonymousObject)
        {
            var dictionary = new Dictionary<string, object>();
            
            if (anonymousObject == null) return dictionary;
            
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(anonymousObject))
            {
                dictionary.Add(propertyDescriptor.Name, propertyDescriptor.GetValue(anonymousObject));
            }
            return dictionary;
        }
    }
