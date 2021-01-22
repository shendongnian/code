    namespace Commandline.Test
    {
    	using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    	[TestClass]
    	public class CommandlineTests
    	{
    		[TestMethod]
    		public void RunNoArguments()
    		{
    			Commandline.Program.Main(new string[0]);
    		}
    	}
    }
