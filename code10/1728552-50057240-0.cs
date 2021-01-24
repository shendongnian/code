    foreach (var extractedRecord in extractedList)
    {   
    	cmd.Parameters[0].Value = extractedRecord.Date;
    	cmd.Parameters[1].Value = extractedRecord.Client;
    	cmd.Parameters[2].Value = extractedRecord.Path;
    	cmd.Parameters[3].Value = DateTime.Now;
    
    	try
    	{
    		cmd.ExecuteNonQuery();
    	}
    	catch (SqlException ex)
    	{
    		if (ex.Number == 2627)
    		{
    			//Violation of primary key. Handle Exception
    			//continue to next iteration
    		}
    	  
    	}
    	
    }
