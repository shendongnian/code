    using (var conn = new SqlConnection(...)) 
    {
      using (var command = new SqlCommand(..., conn))
      {
        command.CommandType = CommandType.StoredProcedure;
        
        // add other parameters here.
        var param = command.Parameters.Add("@FBUserID", SqlDbType.VarChar, 10);
        foreach (string merchant in ConfigurationManager.AppSettings["ids"].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
          param.Value = merchant;
          command.ExecuteNonQuery();
        }
      }
    }
