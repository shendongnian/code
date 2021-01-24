    SqlConnection connection = new SqlConnection("PUT YOUR CONNECTION STRING HERE");
    string loginQuery = "SELECT (User) FROM AdminTable WHERE User = @Username";
    SqlDataAdapter adpt = new SqlDataAdapter(loginQuery, connection);
    adapt.SelectCommand.Parameters.AddWithValue("@Username", user);
    DataSet usr = new DataSet();
    adapt.Fill(usr)
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
