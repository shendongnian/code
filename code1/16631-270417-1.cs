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
            RenderBeginTag(writer);// render only the begin tag.
            //base.RenderContents(writer);
            //base.RenderEndTag(writer);
        }
    
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.Write("<" + this.TagName);
            writer.WriteAttribute("uid", "00101010101");
            writer.Write("/>");
         
        }
    }
    
