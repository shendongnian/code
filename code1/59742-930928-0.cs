    public static class MyAssertExtensions
    {
    	public static void AreEquivalent(this Assert ast, 
    		Dictionary<string, int> propsExpected, 
    		Dictionary<string, int> propsActual)
    	{
    		Assert.AreEqual(propsExpected.Count, propsActual.Count);
    		foreach (var key in propsExpected.Keys)
    		{
    			Assert.IsNotNull(props[key]);
    			Assert.AreEqual(propsExpected[key], props[key]);
    		}
    	}
    }
    
