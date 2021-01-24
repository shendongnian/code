    public SqlConnection DbConnectSql()
    {
        string str = ...;
                   _con = new SqlConnection(str);
        if (_con.State == ConnectionState.Open)
            _con.Close();
        _con.Open();
													public SqlConnection DbConnectSql()
													{
														string str = ...;
																 _con = new SqlConnection(str);
		return _con;
    }
														if (_con.State == ConnectionState.Open)
															_con.Close();
														_con.Open();
														 return _con;
													}
