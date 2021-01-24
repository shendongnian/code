    double num1
    {
        get { return (double)(Session["num1"] ?? 0); }
        set { Session["num1"] = value; }
    } 
