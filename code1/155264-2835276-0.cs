        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label l = (Label)e.Row.FindControl("lblValue");
                l.Text = String.Format("{0:C}", l.Text);
            }
        }
