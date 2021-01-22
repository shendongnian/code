	void Main()
	{
		var dc=this;
		
		// do the SQL query
		var cmd =
			"SELECT Orders.OrderID, Orders.CustomerID, Customers.CompanyName,"
			+"       Customers.Address, Customers.City"
			+" FROM Customers INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID";
		var results = dc.ExecuteQuery<OrderResult>(cmd);
		
		// just get the cities back, ordered ascending
		results.Select(x=>x.City).Distinct().OrderBy(x=>x).Dump();
	}
	
	class OrderResult
	{   // put here all the fields you're returning from the SELECT
		public dynamic OrderID=null; 
		public dynamic CustomerID=null;
		public dynamic CompanyName=null;
		public dynamic Address=null;
		public dynamic City=null;
	}
