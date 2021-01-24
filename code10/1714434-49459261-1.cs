    try
	    {
	        string query = "select * from data";
            List<string> strings = new List<string>();
	        MySqlConnection connect = new MySqlConnection(info);
	        MySqlCommand dbcommand = new MySqlCommand(query, connect);
            connect.Open();
	        myreader = dbcommand.ExecuteReader();
	        while (myreader.Read())
	        {
	            strings.add(Convert.ToString(myreader["type"]));
	        }
	    }
	    catch (Exception ex)
	    {
	    }
	    connect.Close();
