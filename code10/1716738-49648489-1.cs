    if (!string.IsNullOrEmpty(row.Cells[10].Text))
    {
        ddlChange_Requestor.SelectedValue = row.Cells[10].Text;
    }
    else
    {
        ddlChange_Requestor.SelectedIndex = 0;
    }
