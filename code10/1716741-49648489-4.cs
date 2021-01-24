    if (!string.IsNullOrEmpty(row.Cells[10].Text))
    {
        string value = row.Cells[10].Text;
        if (ddlChange_Requestor.Items.Cast<ListItem>().Any(x => x.Value == value))
        {
            ddlChange_Requestor.SelectedValue = value;
        }
        else
        {
            ddlChange_Requestor.SelectedIndex = 0;
        }
    }
