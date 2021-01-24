    void Main()
    {
    	var fooToChange = new List<FooClass>
    	  {
    	    new FooClass { CompanyId = "12345", ProcessId = 2017111701 },
    		new FooClass { CompanyId = "hij", ProcessId = 2018060101 }
    	  };	
    	
    	var foos =
    	  from foo in fooToChange
    	  join fooDb in Foo on
    	    new { CompanyId = foo.CompanyId, ProcessId = foo.ProcessId }
    	    equals 
    		new { CompanyId = fooDb.CompanyId, ProcessId = fooDb.ProcessId }
    	  select fooDb;
    	  
    	foreach(var foo in foos)
    	{
    	  foo.Status = "Sent";
    	}
    	
    	SubmitChanges();
    }
    
    public class FooClass
    {
      public string CompanyId { get; set; }
      public int ProcessId { get; set; }
    }
