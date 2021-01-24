     MySqlConnection con = new MySqlConnection(dataString);
            try
            {
                con.Open();
                (rest of your code)
                con.Close()
            }
            catch 
            {
              (something went wrong)
              con.Close();
            }
