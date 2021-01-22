    //EF6 context not selected in Linqpad Connection dropdown
    var remoteContext = new YourContext();
    remoteContext.Database.Connection.ConnectionString = "Server=[SERVER];Database="
    + "[DATABASE];Trusted_Connection=false;User ID=[SQLAUTHUSERID];Password=" 
    + "[SQLAUTHPASSWORD];Encrypt=True;";
    remoteContext.Database.Connection.Open();
    var DB1 = new Repository(remoteContext);
    //EF6 connection to remote database
    var remote = DB1.GetAll<Table1>()
    	.Where(x=>x.Id==123)
    	//note...depending on the default Linqpad connection you may get 
        //"EntityWrapperWithoutRelationships" results for 
    	//results that include a complex type.  you can use a Select() projection 
        //to specify only simple type columns
    	.Select(x=>new { x.Col1, x.Col1, etc... })
    	.Take(1)
    	.ToList().Dump();  // you must execute query by calling ToList(), ToArray(),
            	  // etc before joining
    //Linq-to-SQL default connection selected in Linqpad Connection dropdown
    Table2.Where(x=>x.Id = 123)
    	.ToList() // you must execute query by calling ToList(), ToArray(),
            	  // etc before joining
    	.Join(remote, a=> a.d, b=> (short?)b.Id, (a,b)=>new{b.Col1, b.Col2, a.Col1})
    	.Dump();
    		
    localContext.Database.Connection.Close();
    localContext = null;
