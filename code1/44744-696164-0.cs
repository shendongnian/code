    protected int iPutName
    {
        get { 
            if (Session["iPutName"] == null)
                Session["iPutName"] == 0;
            return Session["iPutName"];
        }
        set { Session["iPutName"] = value; }
    }
