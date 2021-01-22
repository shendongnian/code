        public static MvcHtmlString NestedActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName, object routeValues = null, object htmlAttributes = null,
            Dictionary<string, Dictionary<string, string>> childElements = null)
        {
            var htmlAttributesDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            if (childElements != null)
            {
                var urlHelper = new UrlHelper();
                var anchorTag = new TagBuilder("a");
                anchorTag.MergeAttribute("href",
                    urlHelper.Action(actionName, controllerName, new RouteValueDictionary(routeValues)));
                anchorTag.MergeAttributes(htmlAttributesDictionary);
                TagBuilder childTag = null;
                foreach (var element in childElements)
                {
                    childTag = new TagBuilder(element.Key);
                    foreach (var attribute in element.Value)
                    {
                        switch (attribute.Key)
                        {
                            case "@class":
                                childTag.AddCssClass(attribute.Value);
                                break;
                            case "InnerText":
                                childTag.SetInnerText(attribute.Value);
                                break;
                            default:
                                childTag.MergeAttribute(element.Key, attribute.Value);
                                break;
                        }
                    }
                    childTag.ToString(TagRenderMode.SelfClosing);
                }
                if (childTag != null) anchorTag.InnerHtml = childTag.ToString();
                return MvcHtmlString.Create(anchorTag.ToString(TagRenderMode.Normal));
            }
            else
            {
                return htmlHelper.ActionLink(linkText, actionName, controllerName, new RouteValueDictionary(routeValues),
                    htmlAttributesDictionary);
            }
        }
