    using System;
    using System.Text;
    using System.IO;
    
    namespace StackOverflow_NET
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			String path = @"C:\myapp\mainfolder";
    			DirectoryInfo info = new DirectoryInfo(path);
    			DirectoryInfo [] sub_directories = info.GetDirectories("*",SearchOption.AllDirectories);
    
    			foreach (DirectoryInfo dir in sub_directories)
    			{
    				Console.WriteLine(dir.Name);
    			}
    		}
    	}
    }
