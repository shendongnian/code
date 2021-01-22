    string expression = string.Join( " OR ", table2.AsEnumerable().Select( 
        row => string.Format( "name='{0}'", row["name"] )).ToArray() );
    			
    foreach( DataRow row in table.Select( expression ) )
    {
        row.Delete();
    }
