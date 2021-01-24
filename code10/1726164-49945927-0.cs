    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddList= e.Row.FindControl("ddl_Project_Owner") as DropDownList;
                if (ddList != null)
                {
                    string sqlStr = "Select distinct Project_Owner from tblProjectHealth order by Project_Owner";
                    DataSet ds = new DataSet();
    
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(ds);
    
                    ddList.DataSource = ds;
                    ddList.DataTextField = "Project_Owner";
                    ddList.DataValueField = "Project_Owner";
                    ddList.DataBind();
    
                   
                }
            }
        }
