    public class State
    {
        public string Something
        {
            get { return HttpContext.Current.Session["Something"] as string; }
            set { HttpContext.Current.Session["Something"] = value; }
        }
    }
