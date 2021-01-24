	using System;
	using System.IO;
	using System.Security.Permissions;
	public class Watcher
	{
		public static void Main()
		{
		Run();
		}
		[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
		public static void Run()
		{
			FileSystemWatcher watcher = new FileSystemWatcher();
			watcher.Path = @"C:\somePath"; // set correct path
			watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
			   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
			watcher.Filter = "*.txt";  // watch for txt only
			watcher.Changed += new FileSystemEventHandler(OnChanged);
			watcher.EnableRaisingEvents = true;
			while(Console.ReadLine()==null); // wait for keypress
		}
		private static void OnChanged(object source, FileSystemEventArgs e)
		{
		   Console.WriteLine("File: " +  e.FullPath + " " + e.ChangeType);
		}
	}
