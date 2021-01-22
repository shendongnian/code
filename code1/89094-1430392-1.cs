    if (!IsPostBack)
    {
        DropDownList1.DataSource = System.Enum.GetValues(typeof (System.Drawing.KnownColor));
        DropDownList1.DataBind();
    }
