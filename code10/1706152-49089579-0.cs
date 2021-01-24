        //Try My code.
        // Call it On form load or IntializeComponent()
        private void GetStrand()
          {//depending on your database bind data like..
             string query="select strand_id,strand_name from strand ";
             using(MysqlConnection con =new MysqlConnection(//your connection string here)
             {
               con.open();
               using(MysqlCommand cmd = new MysqlCommand(query,con)
              {
              MysqlDataReader reader =cmd.ExecuteReader();
              while(reader.read())
              {
               string _strand= reader.GetString("strand_name");
               cbostrand.Items.Add(_strand);
               }
               }
              }
           }
