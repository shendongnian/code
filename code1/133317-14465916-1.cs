    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null && !IsPostBack)
    {
        // ...
    } else if (e.Row.RowType == DataControlRowType.DataRow && IsPostBack)
    {
        // ...
    }
