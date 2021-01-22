    private void BuildDefaultSQLInsert()
    {
    
       // get instance to the object ONCE up front
       // This is a private property on the data manager class of IDbCommand type
       oSQLInsert = GetSQLCommand("");
        
       // pre-build respective insert statement and parameters ONCE. 
       // This way, when actually called, the object and their expected
       // parameter objects already in place.  We just need to update
       // the "Value" inside the parameter
       String SQLCommand = "INSERT INTO MySQLTable ( ";
       String InsertValues = "";
        
       // Now, build a string of the "insert" values to be paired, so
       // add appropriate columns to the string, and IMMEDIATELY add their
       // respective "Value" as a parameter
       DataTable MyTable = GetFromSQL( "Select * from MySQLTable where MyIDColumn = -1" );
       foreach (DataColumn oCol in MyTable.Columns)
       {
          // only add columns that ARE NOT The primary ID column
          if (!(oCol.ColumnName.ToUpper() == "MYIDCOLUMN" ))
          {
             // add all other columns comma seperated...
             SQLCommand += oCol.ColumnName + ",";
       
             InsertValues += "?,";
             // Ensure a place-holder for the parameters so they stay in synch 
             // with the string.  My AddDbParm() function would create the DbParameter
             // by the given column name and default value as previously detected
             // based on String, Int, DateTime, etc...
             oSQLInsert.Parameters.Add(AddDbParm(oCol.ColumnName, oCol.DefaultValue));
          }
       }
        
       // Strip the trailing comma from each element... command text, and its insert values
       SQLCommand = SQLCommand.Substring(0, SQLCommand.Length - 1);
       InsertValues = InsertValues.Substring(0, InsertValues.Length - 1);
        
       // Now, close the command text with ") VALUES ( " 
       // and add  the INSERT VALUES element parms
       SQLCommand += " ) values ( " + InsertValues + " )";
        
       // Update the final command text to the SQLInsert object 
       // and we're done with the prep ONCE
       oSQLInsert.CommandText = SQLCommand;
        
    }
