    public TestClass {
    	public TestName {get;set;}
    }
    public void submain()
    {
    	var originalTestClass = new TestClass()
    	{
    		TestName  ="Test Name";
    	};
    	
    	var newTestClass = new TestClass();
    	 newTestClass.CopyPropertiesFrom(originalTestClass);
    }
