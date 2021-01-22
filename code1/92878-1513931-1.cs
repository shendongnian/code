    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class NFLElim_Reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DetailsView1.DefaultMode = DetailsViewMode.Insert;
                if (DetailsView1.FindControl("UserName") != null)
                {
                    TextBox txt1 = (TextBox)DetailsView1.FindControl("UserName");
                    txt1.Text = User.Identity.Name.ToString();
                }
            }
    
        }
        protected void NFLElim(object sender, DetailsViewInsertedEventArgs e)
        {
            Response.Redirect("Account.aspx");
        }
    
    }
