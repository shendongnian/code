    protected OleDbCommand oSQLInsert = new OleDbCommand();
    // the "?" are place-holders for parameters... can be named parameters, 
    // just for visual purposes 
    oSQLInsert.CommandText = "insert into MyTable ( fld1, fld2, fld3 ) values ( ?, ?, ? )";
    // Now, add the parameters
    OleDbParameter NewParm = new OleDbParameter("parmFld1", 0);
    oSQLInsert.Parameters.Add( NewParm );
    
    NewParm = new OleDbParameter("parmFld2", "something" );
    oSQLInsert.Parameters.Add( NewParm );
    
    NewParm = new OleDbParameter("parmFld3", 0);
    oSQLInsert.Parameters.Add( NewParm );
