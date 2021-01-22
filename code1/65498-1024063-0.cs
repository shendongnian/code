      protected void gvDepartman_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex >=0)
            {
                string selectedid = (gvDepartman).DataKeys[e.Row.RowIndex].Value.ToString();
                e.Row.Attributes["onclick"] = string.Format("location.href='Test.aspx?id={0}'", selectedid);
            }
        }
