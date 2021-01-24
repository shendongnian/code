	public interface IApplication
	{
		void MethodUnderTest(string input);
	}
	
	public class ApplicationWrapper : IApplication
	{
		protected readonly Application _application;
		
		public ApplicationWrapper()
		{
			_application = Application.GetInstance();
		}
		
		public void MethodUnderTest(string input)
		{
			_application.MethodUnderTest(input);
		}
	}
