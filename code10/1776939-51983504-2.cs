    [TestMethod]
    public void TestFail()
    {
    	int invoiceId = 3700;
    	
    	Parallel.For(0, 30, i =>
    	{
    		var srvc = new DbService();
    		srvc.InsertInvoice(invoiceId + i, i);
    
    		if (i > 15)
    		{
    			throw new Exception();
    		}
    	});
    }
