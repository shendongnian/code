    namespace PAB.WebControls
{
    using System;
    using System.ComponentModel;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    [DefaultProperty("Text"),
        ToolboxData("<{0}:SessionTimeoutControl runat=server></{0}:SessionTimeoutControl>")]
    public class SessionTimeoutControl : Control
    {
        private string _redirectUrl;
 
        [Bindable(true),
            Category("Appearance"),
            DefaultValue("")]
        public string RedirectUrl
        {
            get { return _redirectUrl; }
            set { _redirectUrl = value; }
        }
        public override bool Visible
        {
            get { return false; }
        }
        public override bool EnableViewState
        {
            get { return false; }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            if (HttpContext.Current == null)
                writer.Write("[ *** SessionTimeout: " + this.ID + " *** ]");
            base.Render(writer);
        }
 
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (this._redirectUrl == null)
                throw new InvalidOperationException("RedirectUrl Property Not Set.");
            if (Context.Session != null)
            {
                if (Context.Session.IsNewSession)
                {
                    string sCookieHeader = Page.Request.Headers["Cookie"];
                    if ((null != sCookieHeader) && (sCookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        if (Page.Request.IsAuthenticated)
                        {
                            FormsAuthentication.SignOut();
                        }
                        Page.Response.Redirect(this._redirectUrl);
                    }
                }
            }
        }
    }
