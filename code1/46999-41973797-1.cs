	static void Main(string[] args)	{            
	   Method1();            
	}
	
	static void Method1() {
		try	{
			Method2();
		} catch (Exception ex) {
			Console.WriteLine("Exception in Method1");             
		}
	}
	
	static void Method2() {
		try {
			Method3();
		} catch (Exception ex) {
			Console.WriteLine("Exception in Method2");
			Console.WriteLine(ex.TargetSite);
			Console.WriteLine(ex.StackTrace);
			Console.WriteLine(ex.GetType().ToString());
		}
	}
	
	static void Method3() {
		Method4();
	}
	
	static void Method4() {
		try	{
			System.IO.File.Delete("");
		} catch (Exception ex) {
			// Displays entire stack trace into the .NET 
			// or custom library to Method2() where exception handled
			// If you want to be able to get the most verbose stack trace
			// into the internals of the library you're calling
			throw;                
			// throw ex;
			// Display the stack trace from Method4() to Method2() where exception handled
		}
	}
