    using (SqlConnection connection = new SqlConnection(connectionString)){
    connection.Open();
    using (FileStream strm = new FileStream(filePath)){
    using (TextWriter wrt = new TextWriter(strm)){
    SqlCommand cmd = new SqlCommand(sql, connection);
    IDataReader rdr = cmd.ExecuteReader();
    while rdr.Read()
    {
        wrt.Write(rdr[0].ToString() + "|" + rdr[1].ToString(); // change for your manipulation of the columns
    }
    }}}
