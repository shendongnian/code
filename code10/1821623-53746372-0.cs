    public class TestBase
    {
        public virtual void TestMethod()
        {
            Console.WriteLine("TestBase");
        }
    }
    
    public class Test : TestBase
    {
        public override void TestMethod()
        {
            throw new NotImplementedException();
        }
    }
    public class Program
    {
    	public static void Main(string[] args)
        {
    		var testBase = new TestBase();
    		testBase.TestMethod(); // Prints "TestBase"
    		
    		var test = new Test();
    		test.TestMethod(); // Throws NotImplementedException
    	}	
    }
