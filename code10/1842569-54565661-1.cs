    [HtmlTargetElement("checkbox")]
    public class DisabledCheckBox : TagHelper
    {
        [HtmlAttributeName("asp-disabled")]
        public bool IsDisabled { get; set; }
    
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsDisabled)
            {
                var d = new TagHelperAttribute("disabled", "disabled");
                output.Attributes.Add(d);
            }
            base.Process(context, output);
        }
    }
