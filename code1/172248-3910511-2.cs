    [ParseChildren(false)]
    [PersistChildren(true)]
    public class MyControl : CompositeControl 
    {
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            base.RenderBeginTag(writer); // TODO: Do something else here if needed
        }     
     
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            base.RenderEndTag(writer); // TODO: Do something else here if needed
        }
    } 
