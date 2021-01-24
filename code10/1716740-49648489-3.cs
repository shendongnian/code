    if (!string.IsNullOrEmpty(row.Cells[10].Text) && row.Cells[10].Text != "&nbsp;")
    {
        ddlChange_Requestor.SelectedValue = row.Cells[10].Text;
    }
    else
    {
        ddlChange_Requestor.SelectedIndex = 0;
    }
