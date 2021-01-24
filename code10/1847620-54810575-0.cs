    private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=mydatabase;password=mypassword";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string sql =  "SELECT id, last_name FROM people";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                dataGridView1.Rows.Add((string)reader["id"], (string)reader["last_name"]);
                i++;
            }
            conn.Close();
         }
