	public interface IApplication
	{
		void SomeMethod(string input);
	}
	
	public class ApplicationWrapper : IApplication
	{
		protected readonly Application _application;
		
		public ApplicationWrapper()
		{
			_application = Application.GetInstance();
		}
		
		public void SomeMethod(string input)
		{
			_application.SomeMethod(input);
		}
	}
