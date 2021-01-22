    DataTably myTable = GetTable();
    var sql = new StringBuilder();
    sql.Append( "CREATE TABLE [").Append( myTable.TableName ).AppendLine( "] (");
    foreach( DataColumn clm in myTable.Columns ) {
        sql.Append( "[" ).Append( clm.ColumnName ).Append( "] " );
        if ( clm.DataType == typeof( int ) ) { sql.Append( "int" ); }
        else if ( clm.DataType == ... ) { ... }
        ...
    }
    sql.Append( ")" );
