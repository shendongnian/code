    namespace ServerControls
    {
        [ToolboxData("<{0}:LabelWithComment runat=server></{0}:LabelWithComment>")]
        public class LabelWithComment : Label
        {
            protected override void Render(HtmlTextWriter output)
            {
                var htmlFromBaseClass = new StringBuilder();
                var htmlTextWriterForBaseClass = 
                    new HtmlTextWriter(new StringWriter(htmlFromBaseClass));
                base.Render(htmlTextWriterForBaseClass);
                var modifiedHtml = ModifyHtmlUsing(htmlFromBaseClass);
                output.Write(modifiedHtml);
            }
            private static string ModifyHtmlUsing(StringBuilder stringBuilder)
            {
                stringBuilder.Replace("<!-- some comment -->", "");
                return stringBuilder.ToString();
            }
        }
    }
