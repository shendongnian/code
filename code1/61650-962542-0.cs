    SqlConnection SqlConn = new SqlConnection("connection_string_goes_here");
    SqlCommand SqlCmd = new SqlCommand();
    SqlConn.Open();
    SqlCmd.Connection = SqlConn;
    SqlCmd.CommandText = "SELECT isnull(has_perms_by_name('MyDb.dbo.MyTable', " +
        "'OBJECT', 'INSERT'), 0)"
    if (SqlCmd.ExecuteScalar())
    {
       SqlCmd.CommandText =
           "SELECT count(*) FROM UserPermissions WHERE " +
           "Username = " + System.Environment.UserDomainName + "\" + 
               System.Environment.UserName + " " +
           AND Publisher = @Publisher";
       SqlCmd.Parameters.Add("@Publisher", SqlDbType.NVarChar);
       SqlCmd.Parameters("@Publisher").Value = PublisherInput;
       if(SqlCmd.ExecuteScalar())
       {
           SqlCmd.Parameters.Clear();
           SqlCmd.CommandText = "INSERT INTO Books (Title, Publisher) VALUES " +
                                "(@Title, @Publisher)";
           SqlCmd.Parameters.Add("@Title", SqlDbType.NVarChar);
           SqlCmd.Parameters.Add("@Publisher", SqlDbType.NVarChar);
           SqlCmd.Parameters("@Title").Value = TitleInput;
           SqlCmd.Parameters("@Publisher").Value = PublisherInput;
           SqlCmd.ExecuteNonQuery();
       }
    }
    SqlCmd.Dispose();
    SqlConn.Close();
    SqlConn.Dispose();
