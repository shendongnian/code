    //Thread 1
    public SqlConnection DbConnectSql()
    {
        string str = ...;
                   _con = new SqlConnection(str);
        if (_con.State == ConnectionState.Open)
            _con.Close();
        _con.Open();
                                                    //Thread 2
													public SqlConnection DbConnectSql()
													{
														string str = ...;
		//-->Look, thread 2 is overwriting _con-->
                                                 				 _con = new SqlConnection(str);
		return _con;
    }
														if (_con.State == ConnectionState.Open)
															_con.Close();
														_con.Open();
														 return _con;
													}
