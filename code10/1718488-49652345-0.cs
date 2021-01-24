    private const string selectEnumValue = "value";
    
    [HtmlAttributeName(selectEnumValue)]
    public ModelExpression SelectEnumValue { get; set; }
    
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "select";
        output.Attributes.SetAttribute("id", SelectEnumValue.Name);
        output.Attributes.SetAttribute("name", SelectEnumValue.Name);
        output.Content.AppendHtml(Options());
    }
