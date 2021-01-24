    namespace YourProject.PlatformExtensions.TagHelpers
    {
        public static class AnchorTagHelperSettings
        {
            public static string DefaultCulture = "en";
        }
    
        [HtmlTargetElement("a", Attributes = ActionAttributeName)]
        [HtmlTargetElement("a", Attributes = ControllerAttributeName)]
        [HtmlTargetElement("a", Attributes = AreaAttributeName)]
        [HtmlTargetElement("a", Attributes = PageAttributeName)]
        [HtmlTargetElement("a", Attributes = PageHandlerAttributeName)]
        [HtmlTargetElement("a", Attributes = FragmentAttributeName)]
        [HtmlTargetElement("a", Attributes = HostAttributeName)]
        [HtmlTargetElement("a", Attributes = ProtocolAttributeName)]
        [HtmlTargetElement("a", Attributes = RouteAttributeName)]
        [HtmlTargetElement("a", Attributes = RouteValuesDictionaryName)]
        [HtmlTargetElement("a", Attributes = RouteValuesPrefix + "*")]
        public class AnchorTagHelper : Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper
        {
            private const string ActionAttributeName = "asp-action";
            private const string ControllerAttributeName = "asp-controller";
            private const string AreaAttributeName = "asp-area";
            private const string PageAttributeName = "asp-page";
            private const string PageHandlerAttributeName = "asp-page-handler";
            private const string FragmentAttributeName = "asp-fragment";
            private const string HostAttributeName = "asp-host";
            private const string ProtocolAttributeName = "asp-protocol";
            private const string RouteAttributeName = "asp-route";
            private const string RouteValuesDictionaryName = "asp-all-route-data";
            private const string RouteValuesPrefix = "asp-route-";
            private const string Href = "href"; public override int Order => base.Order;
    
            /// <summary>
            /// Creates a new <see cref="AnchorTagHelper"/>.
            /// </summary>
            /// <param name="generator">The <see cref="IHtmlGenerator"/>.</param>
            public AnchorTagHelper(IHtmlGenerator generator) : base(generator)
            {
            }
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                if (!output.Attributes.ContainsName(Href) &&
                    !context.AllAttributes.ContainsName("asp-route-lang") &&
                    !(RouteValues?.ContainsKey("lang") == true))
                {
                    var routeValues = ViewContext?.RouteData?.Values;
    
                    if (routeValues != null)
                    {
                        var langValue = routeValues["lang"]?.ToString();
    
                        if (string.IsNullOrWhiteSpace(langValue))
                        {
                            langValue = AnchorTagHelperSettings.DefaultCulture;
                        }
    
                        if (RouteValues == null)
                        {
                            RouteValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                        }
    
                        RouteValues.Add("lang", langValue);
                    }
                }
    
                base.Process(context, output);
            }
        }
    }
