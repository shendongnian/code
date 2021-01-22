    public  class FbName:System.Web.UI.WebControls.WebControl
    {
    
        protected override string TagName
        {
            get
            {
                return "fb:name";
            }
        }
    
        public override void RenderControl(HtmlTextWriter writer)
        {
            //this is vaguely the default behavior of RenderControl just FYI
            //base.RenderBeginTag(writer); 
            //base.RenderContents(writer);
            //base.RenderEndTag(writer);
    
            RenderBeginTag(writer);// render only the begin tag.
        }
    
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.Write("<" + this.TagName);
            writer.WriteAttribute("uid", "00101010101");
            writer.Write("/>");
         
        }
    }
    
