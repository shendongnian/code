    public void FillTable(DataTable table)
    {
        //Note: it's good practice to close/dispose of database connections and objects here
        conn.Open();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT au.ApplicationId, au.UserId, au.UserName, au.MobileAlias, au.LastActivityDate, au.Name, sms.number, am.email FROM aspnet_users AS au " +
            " JOIN aspnet_membership AS am ON au.userid=am.userid " +
            " JOIN smsphonebooks AS sms ON au.name=sms.name";
        var adapter = new SqlDataAdapter(cmd);
        cmd.Fill(table)
    }
