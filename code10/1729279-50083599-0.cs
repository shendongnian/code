    using (SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader())
    {
        if (objSqlDataReader.Read())
        {
            //objSqlDataReader.Close();// No longer necessary - handled by using
            objSqlConnection.Close();
            Response.Redirect("StudentExamResults.aspx");
        }
        else 
        {
            this.Master.MessageForeColor = System.Drawing.Color.Red;
            this.Master.Message = "The selected examination has not been completed.";
        }
    }
