    [ParseChildren(false)]
    [PersistChildren(true)]
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
        // Create a new implementation of the Text property which
        // will be ignored by the parent class, giving us the freedom
        // to use this property as we please.
        public new string Text
        {
            get { return ViewState["NewText"] as string; }
            set { ViewState["NewText"] = HttpUtility.HtmlDecode(value); }
        }
        protected override void OnPreRender(System.EventArgs e)
        {
            base.OnPreRender(e);
            // I wasn't sure what the best way to handle 'Text' would
            // be. Text is treated as another control which gets added
            // to the end of the button's control collection in this 
            //implementation
            LiteralControl lc = new LiteralControl(this.Text);
            Controls.Add(lc);
            
            // Add a value for base.Text for the parent class
            // If the following line is omitted, the 'value' 
            // attribute will be blank upon rendering
            base.Text = UniqueID;
        }
        protected override void RenderContents(HtmlTextWriter writer)
        {
            RenderChildren(writer);
        }
    }
