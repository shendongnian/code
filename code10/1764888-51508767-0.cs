    ....
    public partial class frmPersonnelVerified : System.Web.UI.Page
    {
     protected void Page_Load(object sender, EventArgs e)
     {
        //Utilize the textbox information to forward to the frmPersonnelVerified page from another page
        txtVerifiedInfo.Text = Session["txtFirstName"] +
            "\n" + Session["txtLastName"] +
            "\n" + Session["txtPayRate"] +
            "\n" + Session["txtStartDate"] +
            "\n" + Session["txtEndDate"];
     }
    }
    
