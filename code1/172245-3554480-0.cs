    public class StyledPanel : System.Web.UI.WebControls.Panel
    {
        public PanelWidth PanelWidth { get; set; }
    
        public override void RenderBeginTag(HtmlTextWriter writer) {            
            string containerClass = string.Format("panel-container-{0}", (int)PanelWidth);
            writer.WriteLine("<div class=\"" + containerClass + "\"" + ">");
        }
    
        public override void RenderEndTag(HtmlTextWriter writer) {
            writer.WriteLine("</div>");
        }
    }
