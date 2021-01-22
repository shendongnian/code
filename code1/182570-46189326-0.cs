    protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                GridViewRow gvRow = (GridViewRow)e.Row;
                HiddenField hfAgentID = (HiddenField)gvRow.FindControl("hfAgentID");
                if (hfAgentID != null)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        DropDownList ddlAgent = (DropDownList)gvRow.FindControl("ddlAgent");
                        ddlAgent.SelectedValue = hfAgentID.Value;
                    }
                }
            }
