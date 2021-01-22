    //Code below is 100% tested
    
    /* FROM ProtectedAndInternal.dll */
    
    namespace ProtectedAndInternal
    {
    	public class MyServiceImplementationBase
    	{
    		protected static class RelevantStrings
    		{
    			internal static string AppName = "Kickin' Code";
    			internal static string AppAuthor = "Scott Youngblut";
    		}
    	}
    	
    	public class MyServiceImplementation : MyServiceImplementationBase
    	{
    		public void PrintProperties()
    		{
       			// WORKS PERFECTLY BECAUSE SAME ASSEMBLY!
    			Console.WriteLine(RelevantStrings.AppAuthor);
    		}
    	}
    	
    	public class NotMyServiceImplementation
    	{
    		public void PrintProperties()
    		{
    			// FAILS - NOT THE CORRECT INHERITANCE CHAIN
    			// Error CS0122: 'ProtectedAndInternal.MyServiceImplementationBase.Relevant' is inaccessible due to its protection level
    			// Console.WriteLine(MyServiceImplementationBase.RelevantStrings.AppAuthor);
    		}
    	}
    }
    
    
    
    /* From AlternateAssemblyService.dll which references ProtectedAndInternal.dll */
    
    namespace AlternateAssemblyService
    {
    	public class MyServiceImplementation : MyServiceImplementationBase
    	{
    		public void PrintProperties()
    		{
    			// FAILS - NOT THE CORRECT ASSEMBLY
    			// Error CS0117: 'ProtectedAndInternal.MyServiceImplementationBase.RelevantStrings' does not contain a definition for 'AppAuthor'
    			// Console.WriteLine(RelevantStrings.AppAuthor);
    		}
    	}
    }
