    public class BasePage : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
    
            if (Session["Context"] == null) 
            {
                // do redirect
            }
        }
    }
