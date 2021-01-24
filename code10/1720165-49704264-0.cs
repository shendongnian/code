    DataTable dt;
    if (Session["tblItems"] != null))
    {
        dt = (DataTable)Session["tblItems"];
        ...
    }
    else
    {
        dt = new DataTable("tblItems1");
        ...
    }
    DataRow dr;
    dr = dt.NewRow();
    ...
