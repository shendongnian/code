     using(SqlConnection con1 = new SqlConnection(connectionString))
     {
      using(SqlCommand cmd1 = new SqlCommand(cmdString, con1))
       {
        con1.Open();
    
        //ExecuteNonQuery Method will return 0 or 1.
        bool result = Convert.ToBool(cmd1.ExecuteNonQuery());
       If insert is succsessful, you can try to execute the second query.
       if(result)
        {  
          If doesn't work, you should check your "Some Code" to be sure if you assign the the right parameters. 
          //Some Code
          cmd1.CommandText = cmdString2;
          cmd1.ExecuteNonQuery();
        }
      }
     }
