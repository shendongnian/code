        public static MvcHtmlString NestedActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName, object routeValues = null, object htmlAttributes = null,
            RouteValueDictionary childElements = null)
        {
            var htmlAttributesDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            
            if (childElements != null)
            {
                var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
                var anchorTag = new TagBuilder("a");
                anchorTag.MergeAttribute("href",
                    routeValues == null
                        ? urlHelper.Action(actionName, controllerName)
                        : urlHelper.Action(actionName, controllerName, routeValues));
                anchorTag.MergeAttributes(htmlAttributesDictionary);
                TagBuilder childTag = null;
                if (childElements != null)
                {
                    foreach (var childElement in childElements)
                    {
                        childTag = new TagBuilder(childElement.Key.Split('|')[0]);
                        object elementAttributes;
                        childElements.TryGetValue(childElement.Key, out elementAttributes);
                        var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(elementAttributes);
                        foreach (var attribute in attributes)
                        {
                            switch (attribute.Key)
                            {
                                case "@class":
                                    childTag.AddCssClass(attribute.Value.ToString());
                                    break;
                                case "InnerText":
                                    childTag.SetInnerText(attribute.Value.ToString());
                                    break;
                                default:
                                    childTag.MergeAttribute(attribute.Key, attribute.Value.ToString());
                                    break;
                            }
                        }
                        childTag.ToString(TagRenderMode.SelfClosing);
                        if (childTag != null) anchorTag.InnerHtml += childTag.ToString();
                    }                    
                }
                return MvcHtmlString.Create(anchorTag.ToString(TagRenderMode.Normal));
            }
            else
            {
                return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributesDictionary);
            }
        }
