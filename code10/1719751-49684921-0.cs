    public partial class summary : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
       {
           if (!IsPostBack) 
           {
                List<Ticket> tickets = (List<Ticket>)Session["tickets"];
    
                // the rest of the code here
           }
       }
       ...
    }
