    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class SessionCSS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if( !Page.IsPostBack)
            {
                Session["DaysAvailable"] = 25;
            }
        }
    
        protected void btnUpdateDays_Click(object sender, EventArgs e)
        {
            Session["DaysAvailable"] = 75;
        }
    }
