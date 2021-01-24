	public static string RetrievemData(customerViewModel model)
    {
        try
        {
            var sqlStatement = @"select * from customertable where last_name=@last_name ";
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_LIB_CONNECTION_STRING"].ConnectionString))
            {
                connection.Open();
                using (var sqlCommand = new SqlCommand(sqlStatement, connection))
                {
                    sqlCommand.Parameters.Add("@last_name", SqlDbType.VarChar).Value = model.LastName;
                    using (var sqlResult = sqlCommand.ExecuteReader())
                    {
                        return sqlResult.HasRows ? "~/ViewPage1" : "~/ViewPage2";
                    }
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception("An error was encountered. " + e);
        }
    }
