    using (MySqlConnection con = new MySqlConnection(conSettings.ToString()))
    {
        using (MySqlCommand cmd2 = new MySqlCommand())
        {
            cmd2.Connection = con;
            cmd2.CommandText = "update shopmanager.paths set path_to_clients = @escapedPath, path_to_employee = @escapedPath1, path_to_procedures = @escapedPath2 where ...";
            cmd2.Parameters.AddWithValue("@escapedPath", a.Replace(@"\", @"\\").Replace("'", @"\'"));
            cmd2.Parameters.AddWithValue("@escapedPath1", b.Replace(@"\", @"\\").Replace("'", @"\'"););
            cmd2.Parameters.AddWithValue("@escapedPath2", c.Replace(@"\", @"\\").Replace("'", @"\'"));
    
            try
            {
                con.Open();
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
