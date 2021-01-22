    public class CurrentUserIdParameter : System.Web.UI.WebControls.Parameter
    {
        
        protected override int Evaluate(System.Web.HttpContext context, System.Web.UI.Control control)
        {
            if (Contact.Current == null) {
                return -1;
            }
            else {
                return Contact.Current.ContactID;
            }
        }
    }
