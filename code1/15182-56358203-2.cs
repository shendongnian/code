    [TestMethod]
    public void ReadFiles()
    {
    	try
    	{
    		Read();
    		return;
    	}
    	catch (Exception ex)
    	{
    		Assert.Fail(ex.Message);
    	}
    }
