     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string strScript = "uncheckOthers(" + ((CheckBox)e.Row.Cells[0].FindControl("CheckBox1")).ClientID + ");";
                    ((CheckBox)e.Row.Cells[0].FindControl("CheckBox1")).Attributes.Add("onclick", strScript);
                }
            }
            catch (Exception Ex)
            {
                //report error
            }        
        }
