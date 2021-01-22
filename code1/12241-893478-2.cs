    public class DefaultButtonPanel:Panel
    {
        protected override void OnLoad(EventArgs e)
        {
            if(!string.IsNullOrEmpty(DefaultButton))
            {
                LinkButton btn = FindControl(DefaultButton) as LinkButton;
                if(btn != null)
                {
                    Button defaultButton = new Button {ID = DefaultButton.Replace(Page.IdSeparator.ToString(), "_") + "_Default", Text = " "};
                    defaultButton.Style.Add("display", "none");
                    PostBackOptions p = new PostBackOptions(btn, "", null, false, true, true, true, true, btn.ValidationGroup);
                    defaultButton.OnClientClick = Page.ClientScript.GetPostBackEventReference(p) + "; return false;";
                    Controls.Add(defaultButton);
                    DefaultButton = defaultButton.ID;
                }
            }
            base.OnLoad(e);
        }
        /// <summary>
        /// Set the default button in a Panel.
        /// The UniqueID of the button, must be relative to the Panel's naming container UniqueID. 
        /// 
        /// For example:
        /// Panel UniqueID is "Body$Content$pnlLogin" 
        /// Button's UniqueID is "Body$Content$ucLogin$btnLogin" 
        /// (because it's inside a control called "ucLogin") 
        /// Set Panel.DefaultButton to "ucLogin$btnLogin".
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="button"></param>
        public override string DefaultButton
        {
            get
            {
                return base.DefaultButton;
            }
            set
            {
                string uniqueId = value;
                string panelIdPrefix = this.NamingContainer.UniqueID + Page.IdSeparator;
                if (uniqueId.StartsWith(panelIdPrefix))
                {
                    uniqueId = uniqueId.Substring(panelIdPrefix.Length);
                }
                base.DefaultButton = uniqueId;
            }
        }      
    }
