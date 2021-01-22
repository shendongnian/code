    SqlDataReader reader = cmd.ExecuteReader();
    
    //print the column names
    for(int i=0; i < reader.FieldCount; i++)
    	Console.Write(reader.GetName(i) + "|");
    Console.WriteLine();
    
    //process each record, note that reader.Read returns one record at a time
    while(reader.Read())
    {
    	for(int i=0; i < reader.FieldCount; i++)
    		Console.Write(reader[i] + "|");
    	Console.WriteLine();
    }
    reader.Close();
