    using System.Data.SQLClient
. . .
    string ConString = "Server=localhost\\SQLEXPRESS2017;Initial Catalog=MyDatabaseName;User=DatabaseUser;Password=SomeSecretPassword;";
    SqlConnection conn;
    SqlCommand cmd;
    SqlDataReader rdr;
    conn = new SqlConnection(ConString);
    conn.Open();
    cmd = new SqlCommand("SELECT Field1, Field2 FROM TableName WHERE Field3=@0;");
    cmd.Parameters.AddWithValue("@0", txtJobNo.Text); // This prevents SQL Injection
    rdr = cmd.ExecuteReader();
    if (rdr.HasRows)
    {
        rdr.Read();
        txtField1.Text = rdr["Field1"];
        txtField2.Text = rdr["Field2"];
    } else
    {
        // Some custom error handling for JobID not found
    }
    rdr.Close();
    conn.Close();
