    connection = new SqlConnection(connectionString);
    string loginQuery = "SELECT (User) FROM AdminTable WHERE User = @Username";
    SqlDataAdapter adpt = new SqlDataAdapter(loginQuery, con);
    adapt.SelectCommand.Parameters.AddWithValue("@Username", user);
    DataSet usr = new DataSet();
    adapt.fill(usr)
    foreach(DataRow dr in usr.Tables[0].Rows)
    { 
      string user += usr.Tables[0].Rows[0]["User"].ToString();
    }
    if(user != "")
    {
        OutputLabel.Text = "Try again";
        return false;
    }
    else
    {
        OutputLabel.Text = "You are logged";
        return true;
    }
