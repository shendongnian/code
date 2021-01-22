    public class ModernButton : Button
    {
        protected override string TagName
        {
            get { return "button"; }
        }
        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Button; }
        }
        public string InnerHtml
        {
            get { return ViewState["Text"]; }
            set { ViewState["Text"] = value; }
        }
        public override string Text
        {
            get { return ViewState["Text"]; }
            set { ViewState["Text"] = HttpUtility.HtmlDecode(value); }
        }
        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write(Text);
        }
    }
