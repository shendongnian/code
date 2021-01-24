    //add IgnorePrepare=false to the connection string
    MySqlConnection Con = new MySqlConnection("Server = localhost; Port = 3306; Database = param_test; Uid = ***; Pwd = ***; SslMode=none; IgnorePrepare=false");
    Con.Open();
    MySqlCommand Cmd = new MySqlCommand("INSERT INTO testtab(TestCol1,TestCol2) VALUES(@test1,@test2)", Con);
    
    Cmd.Parameters.AddWithValue("@test1", "12'34");
    Cmd.Parameters.AddWithValue("@test2", "56");
    
    Cmd.Prepare();  //calling it after Adding the parameters works fine
    Cmd.ExecuteNonQuery();
