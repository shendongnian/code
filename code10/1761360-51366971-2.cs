    using System.Data.SqlClient;
    
    ...
    
    string connectionString = "Data Source=S9; " +
                       "Initial Catalog=Hp; " +
                       "Integrated Security=SSPI";
    string sql = "Insert into tt(cr,TimeSpent_Min,Date,Empid) values (@p1,@p2,@p3,@p4)";
    
    using (var connection = new SqlConnection(connectionString))
    {
        using (var command = new SqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@p1", textBox1.Text);
            command.Parameters.AddWithValue("@p2", textBox2.Text);
            command.Parameters.AddWithValue("@p3", textBox3.Text);
            command.Parameters.AddWithValue("@p4", textBox4.Text);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
    MessageBox.Show("Successfully Inserted");
