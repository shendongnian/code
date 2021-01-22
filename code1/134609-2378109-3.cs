    [ToolboxData("<{0}:MyCustomControl runat=server></{0}:MyCustomControl>")]
    public class MyCustomControl : CompositeControl
    {
        public MyCustomControl()
        {
    	
        }
    
        public override void RenderControl(HtmlTextWriter writer)
        {
            base.RenderEndTag(writer);
    
            if (!this.DesignMode)
            {
                var label = new Label();
                label.Text = "Hello!";
                label.RenderControl(writer);
            }
        }
    }
