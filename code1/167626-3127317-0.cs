    // use nested using block to decrease the indent
    using (var ctx = new DataClassesCallCenterDataContext())
    using (var scope = new TransactionScope())
    {
    	var test =
    		from c in ctx.sp_CallCenterAnketEntity()
    		select c;
    
    	// if you're sure that query result will have at least one record.
        // else an exception will occur. use FirstOrDefault() if not sure.
        // and why int? - is it the type of ID. Isn't int the type?
        int? ID = test.First().ID; 
        // here you can use object initializer
    	var question = new QuestionsYesNo
        {
    	    Question = "Test3?",
    	    Date = DateTime.Now
        };
    
    	ctx.QuestionsYesNos.InsertOnSubmit(question);
    	ctx.SubmitChanges();
    
    	Rehber rehber = (
    		from r in ctx.Rehbers
    		where r.ID == ID
    		select r).First(); // again about being sure and FirstOrDefault
    
    	rehber.Name = @"SQL Server 2005'i bir [many more characters] izleyin.";
    
    	ctx.SubmitChanges();    
    	scope.Complete();
    }
