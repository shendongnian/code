    [HtmlTargetElement("div", Attributes = "messages")]
    public class AlertMessagesTagHelper : TagHelper
    {
        [ViewContext]
        public ViewContext ViewContext { get; set; }
    
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder str = new StringBuilder();
    
            var messages = ViewContext.TempData["error-message"] as List<string>;
            if (messages != null && messages.Any())
            {
                str.Append("<div class='alert alert-danger alert-dismissable'>");
                foreach (var message in messages)
                {
                    str.AppendFormat("<div>{0}</div>", message);
    
                }
                str.Append("</div>");
            }
            output.Content.AppendHtml(str.ToString());
        }
    }
