    public void DumpTableToFile(SqlConnection connection, string tableName, string destinationFile)
    {
        using (var command = new SqlCommand("select * from table " , connection))
        {
            using (var reader = command.ExecuteReader())
            {
                using (StreamWriter sw = new StreamWriter(File.Open(myfilename, FileMode.Create), Encoding.Utf8))
                {    
                    string[] columnNames = GetColumnNames(reader).ToArray();
                    int numFields = columnNames.Length;
                    sw.WriteLine(string.Join(",", columnNames)); // writing headers  
                    
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string[] columnValues = Enumerable.Range(0, numFields)
                                  .Select(i => reader.GetValue(i).ToString())
                                  .Select(field => string.Concat("\"", field.Replace("\"", "\"\""), "\""))
                                  .ToArray();
                            sw.WriteLine(string.Join(",", columnValues));
                        }
                    }
                }
            }
        } 
    }
