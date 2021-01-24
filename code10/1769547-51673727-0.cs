    public class TitleizeTagHelper : TagHelper
    {
        const string ForAttributeName = "asp-for";
        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.SetContent(For.Name.Titleize());
        }
    }
