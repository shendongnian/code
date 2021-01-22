    [TestMethod]
    public void ReadFiles()
    {
    	try
    	{
    		Read();
    		return; // indicates success
    	}
    	catch (Exception ex)
    	{
    		Assert.Fail(ex.Message);
    	}
    }
