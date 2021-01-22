    public override string[] GetRolesForUser(string username)
    {
        SpHelper db = new SpHelper();
        DataTable roleNames = null;
        try
        {
            // get roles for this user from DB...
    
            roleNames = db.ExecuteDataset(ConnectionManager.ConStr,
                        "sp_GetUserRoles",
                        new MySqlParameter("_userName", username)).Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
        string[] roles = new string[roleNames.Rows.Count];
        int counter = 0;
        foreach (DataRow row in roleNames.Rows)
        {
            roles[counter] = row["Role_Name"].ToString();
            counter++;
        }
        return roles;
    }
