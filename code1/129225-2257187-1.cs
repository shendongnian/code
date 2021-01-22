    string filePath = "";
    string connectionString = "";
    FileStream stream = 
       new FileStream(filePath, FileMode.Open, FileAccess.Read);
    BinaryReader reader = new BinaryReader(stream);
    byte[] file = reader.ReadBytes((int)stream.Length);
    reader.Close();
    stream.Close();
                     
    SqlCommand command;
    SqlConnection connection = new SqlConnection(connectionString);
    command = 
       new SqlCommand("INSERT INTO FileTable (File) Values(@File)", connection);
    command.Parameters.Add("@File", SqlDbType.Binary, file.Length).Value = file;
    connection.Open();
    command.ExecuteNonQuery();
