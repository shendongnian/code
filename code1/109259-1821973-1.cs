    public class Userinfo
    {
        public Decimal Latitude
        {
            get { return System.Web.HttpContext.Current.Session["Latitude"]; }
            set { System.Web.HttpContext.Current.Session["Latitude"] = value; }
        }
    }
