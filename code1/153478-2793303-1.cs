    protected void grdStudent_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow dr = ((DataRowView)e.Row.DataItem).Row;
            if (dr["Present"].ToString() == "A")
            {
                ((Label)e.Row.FindControl("yourLableID")).ForeColor= System.Drawing.Color.Red;
            //yourLableID is that lable in which you are showing A or P
            }
        }
    }
