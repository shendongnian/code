using System;
public class MyClass
{
	public static void Main()
	{
		System.AppDomain.CurrentDomain.UnhandledException += MyExceptionHandler;
		System.Threading.ThreadPool.QueueUserWorkItem(DoWork);
		Console.ReadLine();
	}
	
	private static void DoWork(object state)
	{
		throw new ApplicationException("Test");
	}
	
	private static void MyExceptionHandler(object sender, System.UnhandledExceptionEventArgs e)
	{
		// get the message
		System.Exception exception = e.ExceptionObject as System.Exception;
		Console.WriteLine("Unhandled Exception Detected");
		if(exception != null)
			Console.WriteLine("Message: {0}", exception.Message);
		// for this console app, hold the window open until I press enter
		Console.ReadLine();
	}
}
