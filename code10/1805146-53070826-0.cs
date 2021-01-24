       <appSettings>
            <add key="MyConnectionSettings" value="Server=127.0.0.1;Port=3306;Database=myDataBase;Uid=root or user;
        Pwd=yourpassword" />
    
    
    string connectionFromConfig = ConfigurationManager.AppSettings["MyConnectionSettings"];
    using(MySqlConnection con = new MySqlConnection(connectionFromConfig)){
    con.Open();
       string sql = "SELECT *from yourtable";
     MySqlCommand cmd = new MySqlCommand(sql, con );
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0]+" -- "+rdr[1]);
            }
            rdr.Close();
    }
