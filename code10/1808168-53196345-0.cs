    public static class SessionVariables
    {
        public static DataSet StatusInformation
        {
            get
            {
                return (DataSet)HttpContext.Current.Session["StatusInformation"];
            }
            set
            {
                HttpContext.Current.Session["StatusInformation"] = value;
            }
        }
    }
