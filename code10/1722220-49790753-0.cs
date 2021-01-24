    public string temp()
    {
        string test = string.Empty;
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT LEFT(CONVERT(VARCHAR(10),GETDATE(),120),4)
                                + CAST((DATEPART(ISOWK,GETDATE()) - 2) AS NVARCHAR(2))", con);
            con.Open();
            test = (string)cmd.ExecuteScalar();
            con.Close();
        }
        return test;
    }
    protected void gwPlanning_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells.Count > 0)
        {
            //Translate header text
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[12].Text = temp().ToString();    
            }
        }       
     }
