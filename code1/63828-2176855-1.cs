    using CPPLib;
    
    namespace CShartClient
    {
    	class Program
    	{
    		static void Main( string[] args )
    		{
    
    			string a = null;
    			Console.WriteLine( a.MyIsNullOrEmpty() ? "Null Or Empty" : "Not empty" );
    			a = "Test";
    			Console.WriteLine( a.MyIsNullOrEmpty() ? "Null Or Empty" : "Not empty" );
    			Console.ReadKey();
    		}
    	}
    }
