    if (Session["Test"] != null)
    {
        Session["Test"] = (int)(Session["Test"]) + 1;
    }
    else
    {
        Session["Test"] = 1;
    }
    yourLabel.Text = Session["Test"].ToString();
