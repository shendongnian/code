        <%@ Page Language="C#" %>
        <script runat="server">
        private const string SESSION_PARAM = "session";
        private const string SESSION_KEY = "INFOVIEW_SESSION";
        private const string COOKIE_KEY = "InfoViewdotnetses";
        private const string LOGON_URL = "logon.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString[SESSION_PARAM] != null)
                {
                    string sessionStrRaw = Request.QueryString[SESSION_PARAM];
                    string sessionStr = System.Web.HttpUtility.UrlDecode(sessionStrRaw);
                    CrystalDecisions.Enterprise.SessionMgr sessionMgr = new CrystalDecisions.Enterprise.SessionMgr();
                    CrystalDecisions.Enterprise.EnterpriseSession entSession = sessionMgr.GetSession(sessionStr);
                    BusinessObjects.Enterprise.Infoview.Common.CrystalIdentity identity;
                    identity = new BusinessObjects.Enterprise.Infoview.Common.CrystalIdentity(entSession, System.Web.HttpContext.Current);
                    HttpContext.Current.Session.Add(SESSION_KEY, identity);
                    //Create the InfoViewdotnetses cookie which holds the SerializedSession
                    HttpCookie InfoViewdotnetses = new HttpCookie(COOKIE_KEY);
                    InfoViewdotnetses.Value = System.Web.HttpUtility.UrlEncode(sessionStrRaw);
                    InfoViewdotnetses.Path = @"/";
                    Response.Cookies.Add(InfoViewdotnetses);
                }
                Response.Redirect(LOGON_URL);
            }
            catch (Exception ex) { Response.Write(ex.ToString()); }
        }
        </script>
