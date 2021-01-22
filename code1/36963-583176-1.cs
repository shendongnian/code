    string sql = "UPDATE table SET [action_date]= @ActionDate WHERE [id]= @ID";
    
    using (var cn = new SqlConnection("your connection string here."))
    using (var cmd = new SqlCommand(sql, cn))
    {
        cmd.Parameters.Add("@ActionDate", SqlDbTypes.DateTime).Value = 
             ActionDate.Equals("")? DBNull.Value : DateTime.Parse(ActionDate);
        cmd.Parameters.Add("@ID", SqlDbTypes.Int).Value = 2488;
      
        cn.Open();
        cmd.ExecuteNonQuery();
    }
