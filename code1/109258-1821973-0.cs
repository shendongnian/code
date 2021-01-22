    public class Userinfo
    {
        public Decimal Latitude
        {
            get { return System.Web.HttpContext.Current.Session("Latitude"); }
            set { _latitude = System.Web.HttpContext.Current.Session("Latitude", value); }
        }
    }
