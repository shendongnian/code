    [HtmlTargetElement("div", Attributes = FOR_ATTRIBUTE_NAME)]
    public class DivTagHelper : TagHelper
    {
        private const string FOR_ATTRIBUTE_NAME = "si-for";
        /// <summary>
        /// Creates a new <see cref="DivTagHelper"/>.
        /// </summary>
        /// <param name="generator">The <see cref="IHtmlGenerator"/>.</param>
        public DivTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        protected IHtmlGenerator Generator { get; }
        /// <summary>
        /// An expression to be evaluated against the current model.
        /// </summary>
        [HtmlAttributeName(FOR_ATTRIBUTE_NAME)]
        public ModelExpression For { get; set; }
        /// <inheritdoc />
        /// <remarks>Does nothing if <see cref="For"/> is <c>null</c>.</remarks>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = output.Content.IsModified ? output.Content.GetContent() :
                (await output.GetChildContentAsync()).GetContent();
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }
            output.TagName = "div";
            string content;
            if (For.Metadata.UnderlyingOrModelType == typeof(bool))
            {
                content = ((bool?) For.Model).ToYesNo();
            }
            else
            {
                var displayFormatString = For.ModelExplorer.Metadata.DisplayFormatString;
                content = string.IsNullOrEmpty(displayFormatString)
                            ? For.Model?.ToString()
                            : string.Format(displayFormatString, For.Model);
            }
            // Honour the model's specified format if there is one.
            output.Content.SetContent(content);
            output.PostContent.SetHtmlContent(childContent);
        }
    }
