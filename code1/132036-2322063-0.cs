    public static class MySessionHelper
    {
        public static string CustomItem1
        {
            get { return HttpContext.Current.Session["CustomItem1"] as string; }
            set { HttpContext.Current.Session["CustomItem1"] = value; }
        }
        public static int CustomItem2
        {
            get { return (int)(HttpContext.Current.Session["CustomItem2"]); }
            set { HttpContext.Current.Session["CustomItem2"] = value; }
        }
        // etc...
    }
