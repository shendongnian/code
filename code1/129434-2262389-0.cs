    public class CustomScriptManager : WebControl
    {
        private List<string> scripts = new List<string>();
        public List<string> Scripts
        {
            get { return scripts; }
            set { scripts = value; }
        }
        protected override void RenderContents(HtmlTextWriter writer)
        {
            foreach (string script in scripts)
            {
                writer.Write("<script language=\"JavaScript\" type=\"text/javascript\" src=\"" + script + "\"></script>");
            }
        }
    }
