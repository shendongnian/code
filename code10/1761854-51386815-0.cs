    private readonly string SqlConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DillPickle\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30";
    private readonly string SqlDeleteQuery = "DELETE FROM ACCNT WHERE ACCNTNUM=@accountNumber";
    
    private void button4_Click(object sender, EventArgs e)
    {
        try
        {
            using (var sqlConnection = new SqlConnection(SqlConnectionString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlConnection.Open();
                
                sqlCommand.CommandText = SqlDeleteQuery;
                sqlCommand.Parameters.AddWithValue("@accountNumber", textBox2.Text);
                
                sqlCommand.ExecuteNonQuery();
            }
        }  
        catch (Exception ex)
        {
            // Do something with the exception, like log it...
        }
    }
