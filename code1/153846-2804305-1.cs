    public static class SessionHelper
    {
    
        private static HttpSession sess = HttpContext.Current.Session;
        public static int Age
        {
            get
            {
                return (int)sess["Age"];
            }
    
            set
            {
                sess["Age"] = value;
            }
        }
    }
