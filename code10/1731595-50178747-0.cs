	const string query = @"SELECT dp.DeliveryID, dp.Name, da.Adress, da.Location, da.Floor, da.Comments
		FROM DeliveryPhone dp INNER JOIN DeliveryAdress da ON dp.DeliveryID = da.DeliveryID
		WHERE dp.PhoneNumber=@phoneNumber";
	using(SqlCommand command = new SqlCommand(query, con))
	{
	  // I guessed on the sql type and length
	  command.Parameters.Add(new SqlParameter("@phoneNumber", SqlDbType.VarChar, 50) {Value = textBox1.Text});
	  con.Open(); // is the connection always open? Really you should create connections on an as needed basis and then dispose of them
	  using(SqlDataReader read = command.ExecuteReader())
	  {
		if(reader.Read())
		{
		  textBox2.Text = read.GetString(1);
		  comboBox1.Text = read.GetString(2);
		  textBox3.Text = read.GetString(3);
		  comboBox2.Text = read.GetString(4);
		  textBox5.Text = read.GetString(5);
		  // if you need the other values you can get those as well
		}
	  }
	}
