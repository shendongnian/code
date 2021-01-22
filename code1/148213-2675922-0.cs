        // Some engines used named parameters, others may not... The "?"
        // are "place-holders" for the ordinal position of parameters being added...
        String MyQuery = "Update MyTable set SomeField = ?, AnotherField = ? "
            + " where YourKeyField = ?";
        OleDbCommand MyUpdate = new OleDbCommand( MyQuery, YourConnection );
    
       // Now, add the parameters in the same order as the "place-holders" are in above command
       OleDbParameter NewParm = new OleDbParameter( "ParmForSomeField", NewValueForSomeField );
       NewParm.DbType = DbType.Int32;   
       // (or other data type, such as DbType.String, DbType.DateTime, etc)
       MyUpdate.Parameters.Add( NewParm );
    
       // Now, on to the next set of parameters...
       NewParm = new OleDbParameter( "ParmForAnotherField", NewValueForAnotherField );
       NewParm.DbType = DbType.String;   
       MyUpdate.Parameters.Add( NewParm );
    
       // finally the last one...
       NewParm = new OleDbParameter( "ParmForYourKeyField", CurrentKeyValue );
       NewParm.DbType = DbType.Int32;   
       MyUpdate.Parameters.Add( NewParm );
      // Now, you can do you 
      MyUpdate.ExecuteNonQuery();
