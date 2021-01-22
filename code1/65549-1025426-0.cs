	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	namespace ConsoleApplication1
	{
		class Program
		{
			static void Main(string[] args)
			{
				FileInfo f = new FileInfo(args[0]);
				bool result = modifyFile(f, args[1],args[2]);
			}
			private static bool modifyFile(FileInfo file, string extractedMethod, string modifiedMethod) 
			{ 
				Boolean result = false; 
				FileStream fs = new FileStream(file.FullName + ".tmp", FileMode.Create, FileAccess.Write); 
				StreamWriter sw = new StreamWriter(fs); 
				StreamReader streamreader = file.OpenText(); 
				String originalPath = file.FullName; 
				string input = streamreader.ReadToEnd(); 
				Console.WriteLine("input : {0}", input); 
				String tempString = input.Replace(extractedMethod, modifiedMethod); 
				Console.WriteLine("replaced String {0}", tempString); 
				try 
				{ 
					sw.Write(tempString); 
					sw.Flush(); 
					sw.Close(); 
					sw.Dispose(); 
					fs.Close(); 
					fs.Dispose(); 
					streamreader.Close(); 
					streamreader.Dispose(); 
					File.Copy(originalPath, originalPath + ".old", true); 
					FileInfo newFile = new FileInfo(originalPath + ".tmp"); 
					File.Delete(originalPath); 
					File.Copy(originalPath + ".tmp", originalPath, true); 
					result = true; 
				} 
				catch (Exception ex) 
				{ 
					Console.WriteLine(ex); 
				} 
				return result; 
			}
		}
    }
	C:\testarea>ConsoleApplication1.exe file.txt padding testing
	input :         <style type="text/css">
			<!--
			 #mytable {
			  border-collapse: collapse;
			  width: 300px;
			 }
			 #mytable th,
			 #mytable td
			 {
			  border: 1px solid #000;
			  padding: 3px;
			 }
			 #mytable tr.highlight {
			  background-color: #eee;
			 }
			//-->
			</style>
	replaced String         <style type="text/css">
			<!--
			 #mytable {
			  border-collapse: collapse;
			  width: 300px;
			 }
			 #mytable th,
			 #mytable td
			 {
			  border: 1px solid #000;
			  testing: 3px;
			 }
			 #mytable tr.highlight {
			  background-color: #eee;
			 }
			//-->
			</style>
