    [HtmlTargetElement("label", Attributes = ForAttributeName)]
    public class LabelRequiredTagHelper : LabelTagHelper
    {
        private readonly IValidatorFactory _factory;
        private const string ForAttributeName = "asp-for";
    
        public LabelRequiredTagHelper(IHtmlGenerator generator, IValidatorFactory factory) : base(generator)
        {
            _factory = factory;
        }
    
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);
            var validator = _factory.GetValidator(For.Metadata.ContainerType);
    
            var description = validator.CreateDescriptor();
            var propertyValidators = description.GetValidatorsForMember(For.Metadata.PropertyName);
            if (For.Metadata.IsRequired || propertyValidators.Any(p => p is NotNullValidator || p is NotEmptyValidator))
            {
                var sup = new TagBuilder("sup");
                sup.InnerHtml.Append("*");
                output.Content.AppendHtml(sup);
            }
        }
    }
