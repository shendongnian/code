    [TestMethod]
    public void TestGood()
    {
    	int invoiceId = 3700;
    	
    	Parallel.For(0, 30, i =>
    	{
    		DbService srvc = null;
    		
    		try
    		{
    			srvc = new DbService();
    			srvc.InsertInvoice(invoiceId + i, i);
    
    			if (i > 25)
    				throw new Exception();
    		}
    		catch(Exception ex)
    		{
    			if (srvc != null)
    				srvc.Dispose();
    				
                throw ex;
    		}
    	});
    }
