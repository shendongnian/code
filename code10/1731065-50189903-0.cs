    string csv = @"Id, Name, City
    	1, Tom, NY
    	2, Mark, NJ, 100
    	3, Lou, FL
    	4, Smith, PA
    	5, Raj, DC";
    
    StringBuilder sb = new StringBuilder();
    using (var p = ChoCSVReader.LoadText(csv)
    	.WithFirstLineHeader(true) //Ignore the header line to handle the variable length CSV lines
    	.Configure(c => c.MaxScanRows = 5) //Set the max scan rows to the highest to figure out the max fields
    	.Configure(c => c.ThrowAndStopOnMissingField = false)
        )
    {
        foreach (var rec in p)
            Console.WriteLine(rec.DumpAsJson());    
    }
