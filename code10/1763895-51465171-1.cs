    DataTable dtbl = new DataTable();
    using (SqlConnection sqlCon = new SqlConnection(connectionString))
    {
        SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM FeedBackTable WHERE Reviewer = @reviewer", sqlCon);
        sqlDa.SelectCommand.Parameters.AddWithValue("@reviewer",reviewerIdHere); 
        //they said the error was at sqlDa.Fill(dtbl);
        sqlDa.Fill(dtbl);
    }
    gv_feedback.DataSource = dtbl;
    gv_feedback.DataBind();
