	var query = from cust in myDataSet.Tables[0].AsDynamic()
  		where cust.ContactName.StartsWith ("C")
  		orderby cust.ContactName
  		select new { cust.CustomerID, cust.ContactName, cust.City };
		
	query.Dump();	
