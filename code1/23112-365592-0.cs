public class UserLoginController
{
    public static UserLoginController Instance
    {
        get
        {
            HttpSession session = HttpContext.Current.Session;
            if (session["UserLoginController"] == null)
            {
                session["UserLoginController"] = new UserLoginController();
            }
            return session["UserLoginController"] as UserLoginController;
        }
    }
}
