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
        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write(base.Text);
        }
    }
