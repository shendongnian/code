    static void BtnSubmit_Click(object sender, EventArgs e)
    {
    	string valueUser = "test"; //txtUsername.Text;
    
    	using (SqlConnection db = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True"))//SqlDataSource1.ConnectionString);
    	{
    		SqlCommand cmd = new SqlCommand("INSERT INTO dbo.[User] (UserName) VALUES (@valueUser)", db);
    		cmd.Parameters.AddWithValue("@valueUser", valueUser);
    		//cmd.CommandType = CommandType.Text;
    
    		//User is the name of the table, UserName is the column 
    		//cmd.CommandText = "INSERT User (UserName) VALUES (@valueUser)";
    
    		//cmd.Connection = db;
    
    		db.Open();
    
    		try
    		{
    			//cmd.Connection.Open();
    			cmd.ExecuteNonQuery();
    			/*Label1.Text =*/
    			Console.WriteLine("Success writing into database!");
    			//Label1.Visible = true;
    		}
    		catch (Exception ex)
    		{
    			/*Label1.Text =*/
    			Console.WriteLine("Error writing into database.");
    			Console.WriteLine(ex.Message);
    			//Label1.Visible = true;
    		}
    		//finally
    		//{
    			//db.Close();
    		//}
    	}
    }
