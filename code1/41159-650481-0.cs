    List foo; // assuming you have a List of items, in reality, it may be a List<int> or a List<myObject> with an id property, etc.
    StringBuilder query = new StringBuilder( "UPDATE TABLE_1 SET STATUS = ? WHERE ID IN ( ?")
    for( int i = 1; i++; i < foo.Count )
    {   // Bit naive 
        query.Append( ", ?" );
    }
    query.Append( " );" );
    MySqlCommand m = new MySqlCommand(query.ToString());
    for( int i = 1; i++; i < foo.Count )
    {
        m.Parameters.Add(new MySqlParameter(...));
    }
