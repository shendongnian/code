    [HtmlTargetElement(ParentAnchorTag)]
    public class ParentActionTagHelper : TagHelper
    {
        private const string ParentAnchorTag = "p-a";
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext viewContext { get; set; }
        private readonly IHtmlGenerator _htmlGenerator;
        public ParentActionTagHelper(IHtmlGenerator htmlGenerator)
        {
            _htmlGenerator = htmlGenerator;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var anchorTagHelper = new AnchorTagHelper(_htmlGenerator)
            {
                Action = "Privacy",
                ViewContext = viewContext,
            };
            var anchorOutput = new TagHelperOutput("a", new TagHelperAttributeList(),
                (useCachedResult, encoder) =>  Task.Factory.StartNew<TagHelperContent>(
                     () => new DefaultTagHelperContent()));
            anchorOutput.Content.AppendHtml("Privacy Link");
            var anchorContext = new TagHelperContext(
                new TagHelperAttributeList(new[]
                {
                    new TagHelperAttribute("asp-action", new HtmlString("Privacy"))
                }),
                    new Dictionary<object, object>(),
                    Guid.NewGuid().ToString());
            anchorTagHelper.ProcessAsync(anchorContext, anchorOutput).GetAwaiter().GetResult();
            output.Content.SetHtmlContent(anchorOutput);
        }
    }
