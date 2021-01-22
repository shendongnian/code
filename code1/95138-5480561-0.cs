    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Brass9.Testing
    {
    	public static class TestHelper
    	{
    		public static string GetBinPath()
    		{
    			return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    		}
    
    		public static string GetProjectPath()
    		{
    			string appRoot = GetBinPath();
    			var dir = new DirectoryInfo(appRoot).Parent.Parent.Parent;
    			var name = dir.Name;
    			return dir.FullName + @"\" + name + @"\";
    		}
    
    		public static string GetTestProjectPath()
    		{
    			string appRoot = GetBinPath();
    			var dir = new DirectoryInfo(appRoot).Parent.Parent;
    			return dir.FullName + @"\";
    		}
    
    		public static string GetMainProjectPath()
    		{
    			string testProjectPath = GetTestProjectPath();
    			// Just hope it ends in the standard .Tests, lop it off, done.
    			string path = testProjectPath.Substring(0, testProjectPath.Length - 7) + @"\";
    			return path;
    		}
    	}
    }
