    public DataTable GetServerListdt()
            {
                //Create SqlConnection
                MySqlConnection con = new MySqlConnection(cs);
    
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from serversstest", con);
                //MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                //sda.Fill(dt);
                dt.Load(cmd.ExecuteReader());
                con.Close();
                return dt;
            }
