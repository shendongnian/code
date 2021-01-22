    <bo:LinkButton id="Button1" runat="server" ConfirmText="Delete?" />
    public class LinkButton : System.Web.UI.WebControls.LinkButton
    {
        [Bindable(true), Category("Behavior"), DefaultValue("")]
        public string AlertText
        {
            get { return (string)ViewState["AlertText"] ?? string.Empty; }
            set { ViewState["AlertText"] = value; }
        }
    
        [Bindable(true), Category("Behavior"), DefaultValue("")]
        public string ConfirmText
        {
            get { return (string)ViewState["ConfirmText"] ?? string.Empty; }
            set { ViewState["ConfirmText"] = value; }
        }
    
        protected override void CreateChildControls()
        {
            string script = string.Empty;
    
            if (AlertText.Length > 0)
            {
                script += string.Format("alert('{0}');", AlertText);
            }
    
            if (ConfirmText.Length > 0)
            {
                script += string.Format("return confirm('{0}');", ConfirmText);
            }
    
            if (script.Length > 0)
            {
                OnClientClick = script;
            }
    
            base.CreateChildControls();
        }
    }
