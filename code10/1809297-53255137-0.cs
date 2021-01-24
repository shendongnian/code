    // add this line on top of 'using' lines
    using MySql.Data.MySqlClient;
    public string Get(int id)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["JarasDB"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            try
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand("CREATE TABLE Customer(First_Name char(50),Last_Name char(50),Address char(50),City char(50),Country char(25),Birth_Date datetime);", con))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            { 
                // throw exception here 
            }
        }
        return strings[id];
    }
