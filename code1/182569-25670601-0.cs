    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow gvRow in GridView1.Rows)
        {
            RadioButtonList rbl = gvRow.FindControl("rblPromptType") as RadioButtonList;
            HiddenField hf = gvRow.FindControl("hidPromptType") as HiddenField;
            if (rbl != null && hf != null)
            {
                if (hf.Value != "")
                {
                    //clear the default selection if there is one
                    rbl.ClearSelection();
                }
                rbl.SelectedValue = hf.Value;
            }
        }
    }
