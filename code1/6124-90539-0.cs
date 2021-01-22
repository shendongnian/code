    using System.Data;
    using System.Data.SqlClient;
    string connString = "Data Source=...";
    SqlConnection conn = new SqlConnection(connString); // you can also use ConnectionStringBuilder
    connection.Open();
    string sql = "..."; // your SQL query
    SqlCommand command = new SqlCommand(sql, conn);
    // if you're interested in reading from a database use one of the following methods
    // method 1
    SqlDataReader reader = command.ExecuteReader();
    while (reader.Read()) {
        object someValue = reader.GetValue(0); // GetValue takes one parameter -- the column index
    }
    // make sure you close the reader when you're done
    reader.Close();
    // method 2
    DataTable table;
    SqlDataAdapter adapter = new SqlDataAdapter(command);
    adapter.Fill(table);
    // then work with the table as you would normally
    // when you're done
    connection.Close();
