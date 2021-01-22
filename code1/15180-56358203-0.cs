    [TestMethod]
    public void ReadFiles()
    {
    	try
    	{
    		Read();
    	}
    	catch (Exception ex)
    	{
    		Assert.Fail(ex.Message);
    	}
    }
