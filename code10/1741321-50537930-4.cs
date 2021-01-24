    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class MyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    
        protected void btnShow_Click(object sender, EventArgs e)
        {                
            // Pass some data to the ashx handler.
            Session["myData"] = "This is my data.";
    
            // Open PDF in new window and show alert.
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "window.open('ShowPDF.ashx'); alert('OK' );", true);
        }
    }
