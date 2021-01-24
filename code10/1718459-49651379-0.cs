    var builder = new OleDbConnectionStringBuilder();
    builder.Add("Provider", "Microsoft.Jet.OLEDB.4.0");
    builder.Add("Data Source", @"D:\MyBase\");
    builder.Add("Persist Security Info", "False");
    builder.Add("Extended properties", "Paradox 7.x; HDR=YES");
    var command = new OleDbCommand("SELECT * FROM Planes", connection);
    //reading
    connection.Open();
    using (var reader = command.ExecuteReader())
         if (reader.HasRows)
             while (reader.Read())
                   listBox1.Items.Add(reader.GetString(2));
    //writing
    command = new OleDbCommand("DELETE * FROM Planes", connection);
    command.ExecuteNonQuery();
    connection.Close();
