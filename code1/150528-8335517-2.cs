    public static MvcHtmlString TopMenuLink(this HtmlHelper htmlHelper, string linkText, string controller, string action, string area, string anchorTitle)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var url = urlHelper.Action(action, controller, new { @area = area });
            var anchor = new TagBuilder("a");
            anchor.InnerHtml = HttpUtility.HtmlEncode(linkText);
            anchor.MergeAttribute("href", url);
            anchor.Attributes.Add("title", anchorTitle);
            var listItem = new TagBuilder("li");
            listItem.InnerHtml = anchor.ToString(TagRenderMode.Normal);
            
            if (CheckForActiveItem(htmlHelper, controller, action, area))
                listItem.GenerateId("menu_active");
            return MvcHtmlString.Create(listItem.ToString(TagRenderMode.Normal));
        }
        private static bool CheckForActiveItem(HtmlHelper htmlHelper, string controller, string action, string area)
        {
            if (!CheckIfTokenMatches(htmlHelper, area, "area"))
                return false;
            if (!CheckIfValueMatches(htmlHelper, controller, "controller"))
                return false;
            return CheckIfValueMatches(htmlHelper, action, "action");
        }
        private static bool CheckIfValueMatches(HtmlHelper htmlHelper, string item, string dataToken)
        {
            var routeData = (string)htmlHelper.ViewContext.RouteData.Values[dataToken];
            if (routeData == null) return string.IsNullOrEmpty(item);
            return routeData == item;
        }
        private static bool CheckIfTokenMatches(HtmlHelper htmlHelper, string item, string dataToken)
        {
            var routeData = (string)htmlHelper.ViewContext.RouteData.DataTokens[dataToken];
            
            if (dataToken == "action" && item == "Index" && string.IsNullOrEmpty(routeData))
                return true;
            if (dataToken == "controller" && item == "Home" && string.IsNullOrEmpty(routeData))
                return true;
            if (routeData == null) return string.IsNullOrEmpty(item);
            return routeData == item;
        }
