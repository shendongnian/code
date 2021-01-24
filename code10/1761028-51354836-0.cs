        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn  = new SqlConnection("your connection string....");
            try
            {
                cnn.Open();
                SqlCommand  myCommand = new SqlCommand("SQL query....", cnn);
                SqlDataReader reader = myCommand.ExecuteReader();
                while(reader.Read()) 
                {
                     // Access the columns by reader["columnName"]
                }
                // Don't forget to close the connection
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }
