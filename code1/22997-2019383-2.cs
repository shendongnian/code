    using System;
    	using System.Collections.Generic;
    	using System.Linq;
    	using System.Text;
    	using System.Diagnostics;
    	namespace VG
    	{
    		class VGe
    		{
    			[STAThread]
    			static void Main(string[] args)
    			{
    				Process proc = null;
    				try
    				{                
    					string targetDir = string.Format(@"D:\adapters\setup");//this is where mybatch.bat lies
    					proc = new Process();
    					proc.StartInfo.WorkingDirectory = targetDir;
    					proc.StartInfo.FileName = "mybatch.bat";
    					proc.StartInfo.Arguments = string.Format("10");//this is argument
    					proc.StartInfo.CreateNoWindow = false;
    					proc.Start();
    					proc.WaitForExit();
    				}
    				catch (Exception ex)
    				{
    					Console.WriteLine("Exception Occurred :{0},{1}", ex.Message,ex.StackTrace.ToString());
    				}
    			}
    		}
    	}
