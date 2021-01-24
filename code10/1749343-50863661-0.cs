    [HtmlTargetElement("script", Attributes = "src")]
    public class TestTagHelper : TagHelper
    {
        public override int Order => int.MinValue;
    
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!context.AllAttributes.ContainsName("asp-append-version"))
            {
                var scriptTagHelper = new ScriptTagHelper(...) // Inject the required dependencies here
                {
                    AppendVersion = true, // Explicitly set to true
                    // Map all other properties
                };
                scriptTagHelper.Process(context, output);
            }
        }
    }
