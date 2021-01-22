    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class Default10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           btnReset.Attributes.Add("onclick", string.Format("hideOverlay('{0}','{1}')", pnlOverlay.ClientID, pnlAddComment.ClientID));
    
        }
    }
