    	//Your SQL query execution code
        
        //Reads your Customers First
        while (SQLdta.Read())
		{
        }
        //Move the reader to the next returned results table and read the orders
        while (SQLdta.NextResult())
        {
          while (SQLdta.Read())
		  {
          }
        }
