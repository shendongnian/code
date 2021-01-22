    [Test]
    public void CompareObjectsTest()
    {
    	ClassType object1 = ...;
    	ClassType object2 = ...;
    	Assert.That( object1, Is.EqualTo( object2 ).Using( new MyComparer() ) );
    }
    private class MyComparer : IEqualityComparer<ClassType>
    {
    	public bool Equals( ClassType x, ClassType y )
    	{
    		return ....
    	}
    
    	public int GetHashCode( ClassType obj )
    	{
    		return obj.GetHashCode();
    	}
    }
