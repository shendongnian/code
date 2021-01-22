    /*
    * Author: Amen RA
    * # Timestamp: 2013.01.24_02:08:03-UTC-ANKH
    * Licence: General Public License
    */
    using System;
    using System.IO;
    namespace AppCast
    {
	class Program
	{
		public static void Main(string[] args)
		{
			// We are using 2 params
			//the first one is the path of a build exe, i.e: c:\pathto\nin\release\myapp.exe
			string exePath = args[0];
			//the second one is for a file we are going to generate with that info
			string castPath = args[1];
			
			//now we use the methods below
			WriteAppCastFile(castPath, VersionInfo(exePath));
		}
		public static string VersionInfo(string filePath)
		{						
			System.Diagnostics.FileVersionInfo myFileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(filePath);
			return myFileVersionInfo.FileVersion;
		}
		public static void WriteAppCastFile(string castPath, string exeVersion)
		{	
			TextWriter tw = new StreamWriter(castPath);
			tw.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
			tw.WriteLine(@"<item>");
			tw.WriteLine(@"<title>MyApp - New version! Release " + exeVersion + " is available.</title>");
			tw.WriteLine(@"<version>" + exeVersion + "</version>");
			tw.WriteLine(@"<url>http://www.mysite.com/pathto/updates/MyApp.exe</url>");
			tw.WriteLine(@"<changelog>http://www.mysite.com/pathto/updates/MyApp_release_notes.html</changelog>");
			tw.WriteLine(@"</item>");
			tw.Close();			
		}
	}
