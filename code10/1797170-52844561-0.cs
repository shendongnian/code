    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.TagHelpers;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    namespace DL.SO.Framework.Mvc.TagHelpers
    {
        [HtmlTargetElement("span", Attributes = ForAttributeName)]
        public class RawHtmlValidationMessageTagHelper : ValidationMessageHelper
        {
            private const string ForAttributeName = "asp-validation-for";
            [HtmlAttributeName("asp-validation-output-html")]
            public bool OutputHtml { get; set; }
            public RawHtmlValidationMessageTagHelper(IHtmlGenerator generator) : base(generator) {}
            public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
            {
                await base.ProcessAsync(context, output);
                if (this.OutputHtml)
                {
                    using (var writer = new StringWriter())
                    {
                        output.WriteTo(writer, NullHtmlEncoder.Default);
                        output.Content.SetHtmlContent(writer.ToString());
                    }
                }
            }
        }
    }
