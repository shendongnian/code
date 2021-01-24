    public IEnumerable<User> SearchByName(string username)
    {
        var parameters = new List<IDbDataParameter>
        {
        _dbManager.CreateParameter("@Name", 50, username, DbType.String),
        };
        username = "JUSTyou";
        var userDataTable = _dbManager.GetDataTable("SELECT * FROM T_Marke WHERE Name=@Name", CommandType.Text, parameters.ToArray());
        foreach (DataRow dr in userDataTable.Rows)
        {
            var user = new User
            {
                Id = int.Parse(dr["Id"].ToString()),
                Firstname = dr["Name"].ToString(),
            };
            yield return user;
        }
    }
