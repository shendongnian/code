	public sealed class Application
	{
        //private ctor prevents anyone from using new to create this
		private Application() 	
        {
		}
        //Here's the method we want to mock
		public void SomeMethod(string input)
		{
            //Implementation that needs to be stubbed or mocked away for testing purposes
		}
        //Static factory method
		static public Application GetInstance()
		{
			return new Application();
		}
	}
