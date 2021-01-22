    Server server = new Server();
    Database database = new Database( "MyDB" );
    Table table = new Table( database, "MyTable" );
    
    foreach ( Column column in table.Columns )
    {
    	    WriteLine( column.Name ); 
    }	
	
