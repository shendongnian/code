    using(SqlConnection conn = new SqlConnection(connString))
    {
        conn.Open();
        SqlCommand command = new SqlCommand(InsertStmtUsersTable, conn);
        command.CommandType = CommandType.Text;
        command.Parameters.Add(new SqlParameter("username", userNameString));
        command.Parameters.Add(new SqlParameter("password", passwordString));
        command.Parameters.Add(new SqlParameter("email", emailString));
        command.Parameters.Add(new SqlParameter("userTypeId", userTypeId));
        command.Parameters.Add(new SqlParameter("memberId", memberId));
        // Rest of your Parameters here
        var result = (int)command.ExecuteScalar();
    }
