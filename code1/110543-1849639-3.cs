    protected void gvTest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RadioButton rb1 = (RadioButton)e.Row.FindControl("rbSelect1");
            RadioButton rb2 = (RadioButton)e.Row.FindControl("rbSelect2");
            rb1.GroupName = rb2.GroupName = string.Format("Select_{0}", e.Row.RowIndex);
        }
    }
