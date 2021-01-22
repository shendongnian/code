    if (ddlStatus.SelectedValue == "Closed")
    {
     cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50)).Value =
             ddlStatus.SelectedValue;
     cmd.Parameters.Add(new SqlParameter("@Closed_Date", SqlDbType.DateTime)).Value =
             System.DateTime.Now;
    }
    else
    {
     cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50)).Value =
             ddlStatus.SelectedValue;
     cmd.Parameters.Add(new SqlParameter("@Closed_Date", SqlDbType.DateTime)).Value =
             DBNull.Value;
    } 
