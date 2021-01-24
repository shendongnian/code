    void Main()
    {
    	var payrolls = new List<PayrollKey>
    	  {
    	    new PayrollKey { CompanyId = "12345", ProcessId = 2017111701 },
    		new PayrollKey { CompanyId = "hij", ProcessId = 2018060101 }
    	  };    
    	
    	// Store just the companyIds from the incoming list
    	var companyIds = payrolls.Select(x => x.CompanyId);
    
    	// From the DB, get all the foos for the companies in the list.
    	// We will be getting rows for all processIds for a company, but that's ok because:
    	// A) I'm guessing that's not super common, and B) they'll be filtered-out in the next query.
    	var allFoosForCompanies =
    	  from foo in Foo
    	  where foo.Status == "Open" && companyIds.Contains(foo.CompanyId)
    	  select foo;
    	
    	// Now, from the two in-memory lists, get only the foos we care about
    	// (having the correct processId).
    	var foosToChange =
    	  from payroll in payrolls
    	  join foo in allFoosForCompanies on
    	    new { CompanyId = payroll.CompanyId, ProcessId = payroll.ProcessId }
    	    equals 
    		new { CompanyId = foo.CompanyId, ProcessId = foo.ProcessId }
    	  where foo.Status == "Open"
    	  select foo;
    	
    	// Now make the change and save.
    	foreach(var foo in foosToChange)
    	{
    	  foo.Status = "Sent";
    	}
    	SubmitChanges();
    }
     
    public class PayrollKey
    {
      public string CompanyId { get; set; }
      public int ProcessId { get; set; }
    }
