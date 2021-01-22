    public  string FormattedFileName
    {
        get
        {
            return string.Format(
                "{0}_{1}_{2}_{3}.xls", 
                DateTime.Now.Month.ToString().Length == 1 ?
                    "0" + DateTime.Now.Month.ToString() :
                    DateTime.Now.Month.ToString(), 
                DateTime.Now.Day.ToString().Length == 1 ?
                    "0" + DateTime.Now.Day.ToString() :
                    DateTime.Now.Day.ToString(), 
                DateTime.Now.Year.ToString(), 
                "DownLoaded_From_Clients");
        }
    }
