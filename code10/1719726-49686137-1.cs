    [Test]
    public void SomeTest()
    {
    	var context1 = ContextAccessor.Current;
    	var context2 = ContextAccessor.Current;
    
    	Assert.AreSame(context1, context2);
    }
