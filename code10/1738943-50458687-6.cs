	public sealed class Application
	{
        //private ctor prevents anyone from using new to create this
		private Application() 	
        {
		}
        //Here's the method we want to mock
		public void MethodUnderTest(string input)
		{
            //Implementation under test
		}
        //Static factory method
		static public Application GetInstance()
		{
			return new Application();
		}
	}
