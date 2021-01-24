    	//Your SQL query execution code
        
        //Reads your Customers First
        while (SQLdta.Read())
		{
          //Your logic to populate your customers list
        }
        //Move the reader to the next returned results table and read the orders
        while (SQLdta.NextResult())
        {
          while (SQLdta.Read())
		  {
           //Your logic to populate your orders list
          }
        }
