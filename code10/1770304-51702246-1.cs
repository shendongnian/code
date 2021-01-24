     string Seatname = "";
            String output = "";
            string sql = @"select* from[dbo].[BookedTickets]";
            string connectionstring = @"Data 
            Source(local);InitialCatalog=master;Integrated 
            Security=SSPI";
            SqlConnection cnn = new 
            SqlConnection(connectionstring);
            cnn.Open();
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                 Button btn = new Button();
                 btn.Text = SeatNameorWhatEver // set any properties
                 btn.Click += (s,e) => {
                     Button bt = (Button)s;
                     string Seatname = bt.Text;
                   };
            }
