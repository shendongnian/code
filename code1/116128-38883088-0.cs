		public static MvcHtmlString ActionLinkInnerHtml(this HtmlHelper helper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues = null, IDictionary<string, object> htmlAttributes = null, string leftInnerHtml = null, string rightInnerHtml = null)
		{
			// CONSTRUCT THE URL
			var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
			var url = urlHelper.Action(actionName: actionName, controllerName: controllerName, routeValues: routeValues);
			// CREATE AN ANCHOR TAG BUILDER
			var builder = new TagBuilder("a");
			builder.InnerHtml = string.Format("{0}{1}{2}", leftInnerHtml, linkText, rightInnerHtml);
			builder.MergeAttribute(key: "href", value: url);
			// ADD HTML ATTRIBUTES
			builder.MergeAttributes(htmlAttributes, replaceExisting: true);
			// BUILD THE STRING AND RETURN IT
			var mvcHtmlString = MvcHtmlString.Create(builder.ToString());
			return mvcHtmlString;
		}
