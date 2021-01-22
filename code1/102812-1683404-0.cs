    // Object to represent a user
    public class SiteUser
    {
        public String Name { get; set; }
        public UserTypes UserType { get; set; }
    }
    
    // Enumeration of user types
    public enum UserTypes : int
    {
        Admin = 1,
        General = 2
    }
    public partial class Home : System.Web.UI.Page 
    {    
        private void Login()
        {
            // Login method here, take username password etc...
            // This is for example purposes...
            SiteUser user = new SiteUser();
    
            user.UserType = UserTypes.Admin;
            user.Name = "Bob";
    
            Session["User"] = user;
        }
    }
    public partial class AdminOnlyPage : System.Web.UI.Page 
    {    
        private void Page_Load(object sender, EventArgs e)
        {
            // On pages where we want to know the user details
            // cast the session user object back to our SiteUser object.
            SiteUser user = Session["User"] as SiteUser;
    
            // This page is admin only, if our user in session isn't an admin
            // then redirect them else where...
            if (user.UserType != UserTypes.Admin)
            {
                Response.Redirect("/LoginPage.aspx");
            }
        }
    }
    
    
