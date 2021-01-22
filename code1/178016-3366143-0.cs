    using (SqlCeConnection connect = new SqlCeConnection("Data Source=C:\\Users\\mike\\Documents\\database.sdf"))
        {
            connect.Open();
            string text = "test";
            int num = 0;
            using (SqlCeCommand command = new SqlCeCommand("insert into Data Table values (@Value, @Text)", connect))
            {
               command.Parameters.Add("@Value", SqlDbType.NVarChar, num);
               command.Parameters.Add("@Text", SqlDbType.NVarChar, text);
               command.ExecuteNonQuery();
            }
        }
   
     
