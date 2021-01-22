	class ConcreteTest:ATest
    {
        public ConcreteTest(Action<string> statusResponder):base(statusResponder)
        {
        }
        public override void PerformTest()
        {
            // Do some things...
            // And some more...
            statusResponder("changed");
        }
    }
	class Program
	{
	    static void Main(string[] args)
	    {
	        String isPassed = "original";
	        ATest test = new ConcreteTest(status => isPassed = status);
	        test.Start();
	        // Need to add a way to wait for task to be done here
	        Console.WriteLine(isPassed); // Prints out "original"
	    }
	}
	
