    public static class Util
    {
    public static UserInfo UserInfo
        {
            get
            {
                if (HttpContext.Current.Session["UserInfo"] == null)
                {
                    return null;
                }
                return (UserInfo)HttpContext.Current.Session["UserInfo"];
            }
            set
            {
                HttpContext.Current.Session["UserInfo"] = value;
            }
        }
    }
    public class UserInfo
        {
            public string Username { get; set; }
        }
