    public static class Extensions
    {
       	public static int IndexOf<T>(
                this IEnumerable<T> list, 
                Predicate<T> condition) {        		
            int i = -1;
            return list.Any(x => { i++; return condition(x); }) ? i : -1;
       	}
    }
    
    void Main()
    {
    	TestGetsFirstItem();
    	TestGetsLastItem();
    	TestGetsMinusOneOnNotFound();
    	TestGetsMiddleItem();	
    	TestGetsMinusOneOnEmptyList();
    }
    
    void TestGetsFirstItem()
    {
    	// Arrange
    	var list = new string[] { "a", "b", "c", "d" };
    	
    	// Act
    	int index = list.IndexOf(item => item.Equals("a"));
    	
    	// Assert
    	if(index != 0)
    	{
    		throw new Exception("Index should be 0 but is: " + index);
    	}
    	
    	"Test Successful".Dump();
    }
    
    void TestGetsLastItem()
    {
    	// Arrange
    	var list = new string[] { "a", "b", "c", "d" };
    	
    	// Act
    	int index = list.IndexOf(item => item.Equals("d"));
    	
    	// Assert
    	if(index != 3)
    	{
    		throw new Exception("Index should be 3 but is: " + index);
    	}
    	
    	"Test Successful".Dump();
    }
    
    void TestGetsMinusOneOnNotFound()
    {
    	// Arrange
    	var list = new string[] { "a", "b", "c", "d" };
    	
    	// Act
    	int index = list.IndexOf(item => item.Equals("e"));
    	
    	// Assert
    	if(index != -1)
    	{
    		throw new Exception("Index should be -1 but is: " + index);
    	}
    	
    	"Test Successful".Dump();
    }
    
    void TestGetsMinusOneOnEmptyList()
    {
    	// Arrange
    	var list = new string[] {  };
    	
    	// Act
    	int index = list.IndexOf(item => item.Equals("e"));
    	
    	// Assert
    	if(index != -1)
    	{
    		throw new Exception("Index should be -1 but is: " + index);
    	}
    	
    	"Test Successful".Dump();
    }
    
    void TestGetsMiddleItem()
    {
    	// Arrange
    	var list = new string[] { "a", "b", "c", "d", "e" };
    	
    	// Act
    	int index = list.IndexOf(item => item.Equals("c"));
    	
    	// Assert
    	if(index != 2)
    	{
    		throw new Exception("Index should be 2 but is: " + index);
    	}
    	
    	"Test Successful".Dump();
    }        
