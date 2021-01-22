    var table = Authentication.GetTableForApproval();
    if (table.Rows.Count == 0)
    {
        Error.HandleError("There are no forms for approval");
    }
    GvApproveUser.DataSource = table;
    GvApproveUser.DataBind();
