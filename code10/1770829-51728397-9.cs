    void testMethod()
    {
    	x = new ISomeInterfaceAnonymousInnerClass();
    }
    
    private class ISomeInterfaceAnonymousInnerClass : ISomeInterface
    {
    	public void method1()
    	{
            foo();
    	}
    	public void method2()
    	{
            bar();
    	}
    }
