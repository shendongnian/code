    double val;
    if (double.TryParse(System.Configuration.ConfigurationManager.AppSettings["setting"], out val))
    {
        //use val
    }
