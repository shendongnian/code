    public void AssertBusinessRuleException(TestDelegate code, string expectedMessage)
    {
    	var ex = Assert.Throws<BusinessRuleException>(code);
    	Assert.AreEqual(ex.Message, expectedMessage);
    }
    public void AssertException<T>(TestDelegate code, string expectedMessage) where T:Exception
    {
    	var ex = Assert.Throws<T>(code);
    	Assert.AreEqual(ex.Message, expectedMessage);
    }
