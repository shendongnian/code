    using System;
    
    namespace PlayAreaCSCon
    {
    	internal class Program
    	{
    		static void Main(string[] args)
    		{
    			TestTryCatchFinally();
    			Console.WriteLine("Complete");
    			Console.ReadLine();
    		}
    
    		private static void TestTryCatchFinally()
    		{
    			try
    			{
    				Console.WriteLine("Start Outer Try");
    				try
    				{
    					Console.WriteLine("Start Inner Try");
    					throw new Exception("Exception from inner try");
    				}
    				finally
    				{
    					Console.WriteLine("In Inner Finally");
    				}
    			}
    			catch (Exception ex) when (GuardHelper(ex))
    			{
    				Console.WriteLine("In outer catch");
    			}
    			finally
    			{
    				Console.WriteLine("In outer finally");
    			}
    
    			bool GuardHelper(Exception ex)
    			{
    				Console.WriteLine("In outer guard");
    				return true;
    			}
    		}
    	}
    }
