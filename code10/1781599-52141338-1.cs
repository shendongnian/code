    public ObservableCollection<User> GetUsers()
    {
        var UserList = new ObservableCollection<User>();
        string query;
        query = "select * from users";
        da = new MySqlDataAdapter(query, db.GetConnection());
        da.Fill(dt);
        foreach (DataRow rw in dt.Rows) { UserList.Add(new User(row)); }        
        return UserList;
    }
