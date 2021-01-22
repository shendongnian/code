    [DefaultProperty("Text")]
    [DefaultEvent("Click")]
    [ToolboxData("<{0}:ImgButton runat=server></{0}:ImgButton>")]
    public class ImgButton : WebControl, IPostBackEventHandler
    {
        #region Public Properties
        public enum ImgButtonStyle
        {
            Button,
            Anchor
        }
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }
            set
            {
                ViewState["Text"] = value;
            }
        }
        [EditorAttribute(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
        public string ImgSrc { get; set; }
        public string CommandName { get; set; }
        public string CommandArgument { get; set; }
        [EditorAttribute(typeof(System.Web.UI.Design.UrlEditor), typeof(UITypeEditor))]
        public string NavigateUrl { get; set; }
        public string OnClientClick { get; set; }
        public ImgButtonStyle RenderStyle { get; set; }
        [DefaultValue(true)]
        public bool UseSubmitBehavior { get; set; }
        [DefaultValue(true)]
        public bool CausesValidation { get; set; }
        public string ValidationGroup { get; set; }
        [DefaultValue(0)]
        public int Tag { get; set; }
        #endregion
        #region Constructor
        public ImgButton()
        {
            Text = "Text";
            ImgSrc = "~/Masters/_default/img/action-help.png";
            UseSubmitBehavior = true;
            CausesValidation = true;
        }
        #endregion
        #region Events
        // Defines the Click event.
        public event EventHandler Click;
        public event CommandEventHandler Command;
        protected virtual void OnClick(EventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
            }
        }
        protected virtual void OnCommand(CommandEventArgs e)
        {
            if (Command != null)
            {
                Command(this, e);
            }
            RaiseBubbleEvent(this, e);
        }
        public void RaisePostBackEvent(string eventArgument)
        {
            if (CausesValidation)
            {
                Page.Validate(ValidationGroup);
                if (!Page.IsValid) return;
            }
            OnClick(EventArgs.Empty);
            if (!String.IsNullOrEmpty(CommandName))
                OnCommand(new CommandEventArgs(CommandName, CommandArgument));
        }
        #endregion
        #region Rendering
        // Do not wrap in <span> tag
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.Write("");
        }
        
        protected override void RenderContents(HtmlTextWriter output)
        {
            string click;
            string disabled = (Enabled ? "" : "disabled ");
            string type = (String.IsNullOrEmpty(NavigateUrl) && UseSubmitBehavior ? "submit" : "button");
            string imgsrc = ResolveUrl(ImgSrc ?? "");
            if (String.IsNullOrEmpty(NavigateUrl))
                click = Page.ClientScript.GetPostBackEventReference(this, "");
            else
                if (NavigateUrl != null)
                    click = String.Format("location.href='{0}'", ResolveUrl(NavigateUrl));
                else
                    click = OnClientClick;
            switch (RenderStyle)
            {
                case ImgButtonStyle.Button:
                    if (String.IsNullOrEmpty(NavigateUrl) && UseSubmitBehavior)
                    {
                        output.Write(String.Format(
                            "<button id=\"{0}\" {1}class=\"{2}\" type=\"{3}\" name=\"{4}\" title=\"{5}\"><img src=\"{6}\" alt=\"{5}\"/>{7}</button>",
                            ClientID,
                            disabled,
                            CssClass,
                            type,
                            UniqueID,
                            ToolTip,
                            imgsrc,
                            Text
                        ));
                    }
                    else
                    {
                        output.Write(String.Format(
                            "<button id=\"{0}\" {1}class=\"{2}\" type=\"{3}\" name=\"{4}\" onclick=\"javascript:{5}\" title=\"{6}\"><img src=\"{7}\" alt=\"{6}\"/>{8}</button>",
                            ClientID,
                            disabled,
                            CssClass,
                            type,
                            UniqueID,
                            click,
                            ToolTip,
                            imgsrc,
                            Text
                        ));
                    }
                    break;
                case ImgButtonStyle.Anchor:
                    output.Write(String.Format(
                        "<a id=\"{0}\" {1}class=\"{2}\" onclick=\"javascript:{3}\" title=\"{4}\"><img src=\"{5}\" alt=\"{4}\"/>{6}</a>",
                        ID,
                        disabled,
                        CssClass,
                        click,
                        ToolTip,
                        imgsrc,
                        Text
                    ));
                    break;
            }
        }
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.Write("");
        }
        #endregion
    }
