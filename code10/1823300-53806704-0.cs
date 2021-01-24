    public class TestClass : IEquatable<TestClass>
    {
        public int TestValue01 { get; private set; }
    	public int TestValue02 { get; private set; }
    
    	public TestClass(int testValue01, int testValue02)
    	{
    		TestValue01 = testValue01;
    		TestValue02 = testValue02;
    	}
    
    	public override bool Equals(object obj)
    	{
    		return Equals(obj as TestClass);
    	}
    
    	public bool Equals(TestClass other)
    	{
    		return other != null &&
    		    TestValue01 == other.TestValue01 &&
    		    TestValue02 == other.TestValue02;
    	}
    
    	public static bool operator ==(TestClass test1, TestClass test2)
    	{
    		return EqualityComparer<TestClass>.Default.Equals(test1, test2);
    	}
    
    	public static bool operator !=(TestClass test1, TestClass test2)
    	{
    		return !(test1 == test2);
    	}
    }
