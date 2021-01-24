    try
    {
    	queryInsert.ExecuteNonQuery();
    }
    catch (SqlException e)
    {
    
    	if (exc.Number == 2601)
    	{
    		MessageBox.show("Your Record is already exists");
    	}
    	else
    	{
    		MessageBox.show(e.Message());
    	}
    }
    catch(Exception e)
    {
    	// other kind of exception
    }
