    public class UserContext
    {
        private UserContext()
        {
        }
        public static UserContext Current
        {
            get
            {
                if (HttpContext.Current.Session["UserContext"] == null)
                {
                    var uc = new UserContext
                                 {
                                     StringList = new List<string>()
                                 };
                    HttpContext.Current.Session["UserContext"] = uc;
                }
                return (UserContext) HttpContext.Current.Session["UserContext"];
            }
        }
        public List<string> StringList { get; set; }
    }
