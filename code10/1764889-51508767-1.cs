    ....
    public partial class frmPersonnelVerified : System.Web.UI.Page
    {
     protected void Page_Load(object sender, EventArgs e)
     {
        //Utilize the textbox information to forward to the frmPersonnelVerified page from another page
        txtVerifiedInfo.Text = Session["txtFirstName"].ToString() +
            "\n" + Session["txtLastName"].ToString() +
            "\n" + Session["txtPayRate"].ToString() +
            "\n" + Session["txtStartDate"].ToString() +
            "\n" + Session["txtEndDate"].ToString();
     }
    }
    
