    private static void ConctDatabase(string connectionString)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            MessageBox.Show("Database: {0}", conn.Database);
            conn.ChangeDatabase("Northwind");
            MessageBox.Show("Database: {0}", conn.Database);
        }
    }
