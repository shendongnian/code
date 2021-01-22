    var table = Authentication.GetTableForApproval();
    if (table.Rows.Count > 0)
    {
        GvApproveUser.DataSource = table;
        GvApproveUser.DataBind();
    }
    else
    {
        // hide the gridview and show a message
    }
