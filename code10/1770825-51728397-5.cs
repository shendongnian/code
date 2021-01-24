    void testMethod()
    {
    	x = new ISomeInterfaceAnonymousInnerClass();
    }
    
    private class ISomeInterfaceAnonymousInnerClass : ISomeInterface
    {
    	public override void method1()
    	{
            foo();
    	}
    	public override void method2()
    	{
            bar();
    	}
    }
