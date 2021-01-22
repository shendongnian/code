    if (e.Row.RowType = DataControlRowType.Header)
    {
        e.Row.Cells[0].Controls.Clear();
        var ddlFilter = new DropDownList();
        //add options etc
        e.Row.Cells[0].Controls.Add(ddlFilter);
    }
