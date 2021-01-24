    public static void ReadUsersInfo(string connectionString)
    {
        const string query = "select * from dbo.users";
    
        using (var dataTable = new DataTable())
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var dataAdapter = new SqlDataAdapter(query, sqlConnection))
                {
                    dataAdapter.Fill(dataTable);
                }
            }
    
            foreach (DataRow dr in dataTable.Rows)
            {
                Console.WriteLine(dr["user"].ToString());
            }
        }
    
        Console.ReadKey();
    }
