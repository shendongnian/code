	public void UpdateCustomer(string strCustomerName, string strDescription)
	{
	  using (var transaction = CreateTransactionScope())
	  {
		MyCustomer tbl=null;
		Func<MyCustomer, bool> selectByName=(i => i.CustomerName.Equals(strCustomerName));
        var doesRecordExistAlready = dc.MyCustomers.Any(selectByName); 
		if (doesRecordExistAlready) 
		{
			// Updating
			tbl=dc.MyCustomers.Where(selectByName).FirstOrDefault();		
		    tbl.Description=strDescription;
		}
		else
		{
			// Inserting
			tbl=new MyCustomer(); 
			var maxItem=
               dc.MyCustomers.OrderByDescending(i => i.CustomerId).FirstOrDefault();
			var newID = maxItem==null ? 1 : maxItem.CustomerId+1;
			tbl.CustomerId=newID;
   		    tbl.CustomerName=strCustomerName; 
		    tbl.Description=strDescription;
			dc.MyCustomers.AddObject(tbl); 		
		}
		dc.SaveChanges(); // save all changes consistently			
		transaction.Complete(); // commit
	  }
	}
