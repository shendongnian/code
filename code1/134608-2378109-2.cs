    [ToolboxData("<{0}:MyCustomControl runat=server></{0}:MyCustomControl>")]
    public class MyCustomControl : CompositeControl
    {
        public MyCustomControl()
        {
    	
        }
    
        public string Text
        {
            get
            {
                object o = ViewState["Text"];
                return ((o == null) ? "Set my text!" : (string)o);
    	    }
            set
            {
                ViewState["Text"] = value;
            }
        }
    
        protected override void CreateChildControls()
        {
            // Create controls
            var label = new Label();
            label.ID = "innerLabel";
            label.Text = this.Text;
    
            // Add controls
            this.Controls.Add(label);
    
            // Call base method
            base.CreateChildControls();
        }
    }
