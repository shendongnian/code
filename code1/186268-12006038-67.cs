	var Customers = myDataSet.Tables[0].AsDynamic(); // convert it to IEnumerable<Object>
	var query = from cust in Customers // now use the table's fieldnames
  		where cust.ContactName.StartsWith ("C")
  		orderby cust.ContactName
  		select new { cust.CustomerID, cust.ContactName, cust.City };
		
	query.Dump();	
