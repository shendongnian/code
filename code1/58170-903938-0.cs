    public class BasePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(this.Master != null)
              if(this.Master.FindControl("Control A") != null)
                  //Disable Control A
                  //Enabled Control B
        }
    }
