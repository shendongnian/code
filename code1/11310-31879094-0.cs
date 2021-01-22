    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace ModernControls
    {
        [ParseChildren]
        public class ModernButton : Button
        {
            public new string Text
            {
                get { return (string)ViewState["NewText"] ?? ""; }
                set { ViewState["NewText"] = value; }
            }
            public string Value
            {
                get { return base.Text; }
                set { base.Text = value; }
            }
            protected override HtmlTextWriterTag TagKey
            {
                get { return HtmlTextWriterTag.Button; }
            }
            protected override void AddParsedSubObject(object obj)
            {
                var literal = obj as LiteralControl;
                if (literal == null) return;
                Text = literal.Text;
            }
            protected override void RenderContents(HtmlTextWriter writer)
            {
                writer.Write(Text);
            }
        }
    }
