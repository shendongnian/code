    protected void MyGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType.Equals(DataControlRowType.DataRow))
        {
            foreach (DataControlFieldCell cell in e.Row.Cells)
            {
                foreach(Control control in cell.Controls)
                {
                    LinkButton lb = control as LinkButton;
    
                    if (lb != null && lb.CommandName == "Edit")
                        lb.Attributes.Add("onclick", "SetScrollEvent();");
                }
            }
        }
    }
