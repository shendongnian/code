    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace MyCompany.Deployment
    {
    	/// <summary>
    	/// Enables a quick and easy method of debugging custom actions.
    	/// </summary>
    	class LogFile
    	{
    		const string FileName = "MyCompany.Deployment.log";
    		readonly string _filePath;
    
    		public LogFile(string primaryOutputPath)
    		{
    			var dir = Path.GetDirectoryName(primaryOutputPath);
    			_filePath = Path.Combine(dir, FileName);
    		}
    
    		public void Print(Exception ex)
    		{
    			File.AppendAllText(_filePath, "Error: " + ex.Message + Environment.NewLine +
    					"Stack Trace: " + Environment.NewLine + ex.StackTrace + Environment.NewLine);
    		}
    
    		public void Print(string format, params object[] args)
    		{
    			var text = String.Format(format, args) + Environment.NewLine;
    
    			File.AppendAllText(_filePath, text);
    		}
    
    		public void PrintLine() { Print(""); }
    	}
    }
