    [SetUpFixture]
    	public void setUpClass(){
    	    // Marks a class with one-time setup or teardown methods for all the test fixtures in a namespace.
    		// instantiate your driver object here // 
    	}
    	
    [SetUp]
    	public void setUpMethod(){
    		// Indicates a method of a TestFixture called just before each test method.
    		// your login or before method activity(which would be running before every test method)
    	}
    	
    [Test]
    	public void testMethod1(){
    		// Marks a method of a TestFixture that represents a test.
    		// Your Test Method.
    	}
    	
    [Test]
    	public void testMethod2(){
    		// Marks a method of a TestFixture that represents a test.
    		// Your Test Method.
    	}
    	
    [TearDown]
    	public void tearDownMethod(){
    		 // Indicates a method of a TestFixture called just after each test method.
    		 // your log out or after method activity(which would be running after every test method) 
    	}
    	
    }
