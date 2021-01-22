    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Services;
    
    public partial class ClearSessionOnPageUnload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        [WebMethod]
        public static void AbandonSession()
        {
            HttpContext.Current.Session.Abandon();
        }
    
    }
