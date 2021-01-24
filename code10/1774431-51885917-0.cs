    class MainClass
    	{
    		public static void Main(string[] args)
    		{
    			List<DBT_Master> list = new List<DBT_Master>();
    			list.Add(new DBT_Master { CustomerCode = "test" });
    			list.Add(new DBT_Master { CustomerCode= "test1" });
    			list.Add(new DBT_Master { CustomerCode = "test12" });
    			list.Add(new DBT_Master { CustomerCode = "test13" });
                
    			List<DBT_MASTER_ADDRESS> list2 = new List<DBT_MASTER_ADDRESS>();
    			list2.Add(new DBT_MASTER_ADDRESS { AddressCode = "1234", CustCode="test" });
    			list2.Add(new DBT_MASTER_ADDRESS { AddressCode = "asdfs", CustCode = "test" });
    			list2.Add(new DBT_MASTER_ADDRESS { AddressCode = "afsadfas" });
    			list2.Add(new DBT_MASTER_ADDRESS { AddressCode = "fdsa" });
    
    			var customerCode = "test";
    			var siteNo = "1234";
    
    			var query = (from x in list.AsQueryable()
    						 join p in list2.AsQueryable() on x.CustomerCode equals p.CustCode
    						 select new { DBT_Master = x, DBT_MASTER_ADDRESS = p });
       
    			if (customerCode != "")
    			{
    				query = query.Where(x => x.DBT_Master.CustomerCode == customerCode);
    			}
    
    			if (siteNo != "")
    			{
    				query = query.Where(x => x.DBT_MASTER_ADDRESS.AddressCode == siteNo);
    			}
    
			query.Select(x => x.DBT_Master).ToList().ForEach(x => Console.WriteLine(x));
    		}
    	}
    
    	class DBT_Master
    	{
    		public string CustomerCode { get; set; }
    
    		public override string ToString()
    		{
    			return CustomerCode;
    		}
    	}
    
    	class DBT_MASTER_ADDRESS {
    		public string AddressCode { get; set; }
            public string CustCode { get; set; }
    
    		public override string ToString()
    		{
    			return AddressCode + " " + CustCode;
    		}
    	}
