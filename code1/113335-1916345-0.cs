    namespace ServerControl1
    {
        [DefaultProperty("Text")]
        [ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
        public class TextBoxWithChange : TextBox
        {
            [Bindable(true)]
            [Category("Appearance")]
            [DefaultValue("")]
            [Localizable(true)]
            public bool HasEntityChanged
            {
                get
                {
                    bool hasEntityChanged = (bool) ViewState["HasEntityChanged"];
                    return hasEntityChanged;
                }
            }
    
            protected override void RenderContents(HtmlTextWriter output)
            {
                output.Write(Text);
            }
        }
    }
