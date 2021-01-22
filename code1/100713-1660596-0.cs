      // Create a record object that represents an individual row, including it's metadata.
          SqlDataRecord record = new SqlDataRecord(new SqlMetaData("stringcol", SqlDbType.NVarChar, 128));
          
          // Populate the record.
          record.SetSqlString(0,( "Hello World!" + System.DateTime.Now));
          
          // Send the record to the client.
          SqlContext.Pipe.Send(record);
