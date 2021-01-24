    [HtmlTargetElement("icon", Attributes = "")]
    public class IconTagHelper : TagHelper
    {
        [HtmlAttributeName("name")]
        public string IconName { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            string classAttribute = $@"fa fa-{IconName}";
            output.Attributes.Add("class", classAttribute);
        }
    }
