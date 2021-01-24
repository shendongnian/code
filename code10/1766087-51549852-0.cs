                MySqlConnection connection = new 
               MySqlConnection(myConnectionString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                EncodingProvider ppp;
                ppp = CodePagesEncodingProvider.Instance;
                Encoding.RegisterProvider(ppp);
                connection.Open();
                string select = "Select time from assign where userId=@name";
                cmd.Parameters.AddWithValue("@name", txtValue.Text);
                cmd.CommandText = select;
                cmd.Connection = connection;
                MySqlDataReader selectAssign = cmd.ExecuteReader();
                selectAssign.Read();
                string assign = (selectAssign["time"].ToString());
                selectAssign.Close();
                DateTime assignDate = DateTime.Now;
                DateTime.TryParseExact(assign, out assignDate);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT into bluetooth 
    (userId,arm,armNumberDone,armNumber,comDate,assignDate,status) VALUES (@name, 
    @stupid0, @stupid1, @stupid2, @stupid3, @stupid4, @stupid5)";
                cmd.Parameters.AddWithValue("@stupid0", databaseLine);
                cmd.Parameters.AddWithValue("@stupid1", counter);
                cmd.Parameters.AddWithValue("@stupid2", databaseValue);
                cmd.Parameters.AddWithValue("@stupid3", DateTime.Now);
                cmd.Parameters.AddWithValue("@stupid4", assignDate);
                cmd.Parameters.AddWithValue("@stupid5", complete);
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                txtExercise.Text = ex.ToString();
            }
        }
