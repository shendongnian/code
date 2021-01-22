    protected void grdStudent_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow dr = ((DataRowView)e.Row.DataItem).Row;
            if (dr["Present"].ToString() == "A")
            {
                e.Row.BackColor = System.Drawing.Color.Red;
            }
        }
    }
