    public void FillTable(DataTable table)
    {
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT au.ApplicationId, au.UserId, au.UserName, au.MobileAlias, au.LastActivityDate, au.Name, sms.number, am.email FROM aspnet_users AS au " +
            " JOIN aspnet_membership AS am ON au.userid=am.userid " +
            " JOIN smsphonebooks AS sms ON au.name=sms.name";
        using(var adapter = new SqlDataAdapter(cmd))
            adapter.Fill(table)
    }
