    // Notice that you are missing the third field (the image one)
    // Please replace Image with the correct name of the image field in your table
    string query = @"INSERT INTO example (Name, Description, Image) 
                     VALUES (@name, @description, @img";
    MySqlCommand cmd = new MySqlCommand(query, dbConn);
    cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = u;
    cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = v;
    cmd.Parameters.Add("@img", MySqlDbType.Binary).Value = img;
    dbConn.Open();
    // Do not execute the query two times.
    // cmd.ExecuteNonQuery();
    if (cmd.ExecuteNonQuery() == 1)
    {
        MessageBox.Show("Succesfully added!");
        int id = (int)cmd.LastInsertedId;
        ....
    }
    else
    {
        // failure msg ?
    }
