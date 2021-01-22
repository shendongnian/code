    public static Data SomeData
    {
        get
        {
            if (HttpContext.Session["SomeData"] == null)
                HttpContext.Session["SomeData"] = new Data();
            return (Data)HttpContext.Session["SomeData"];
        }
    }
