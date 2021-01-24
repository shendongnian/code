    if (accountCharCount > 0)
    {
        string query1 = "INSERT INTO playercharacter(id, connection_ID) VALUES((SELECT id FROM account WHERE connection_ID='" + connectionID + "'), (SELECT connection_ID FROM account WHERE connection_ID='" + connectionID + "'))";
        using (MySqlCommand cmd = new MySqlCommand(query1, MySQL.mySQLsettings.connection))
        {
            try
            {             
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
