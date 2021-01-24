	using System;
	using System.Threading.Tasks;
	using System.IO;
	using System.Collections.Concurrent;
	namespace Test
	{
	    class Program
	    {
		static void Main(string[] args)
		{
		    GetFilesOnRoot("*");            
		    Console.ReadLine();
		}
		private static ConcurrentBag<string> FilesBag;
		private static void GetFilesOnRoot(string filter)
		{
		    FilesBag = new ConcurrentBag<string>();
		    DirectoryInfo dirRoot = new DirectoryInfo("/");
		    GetDirTree(dirRoot, "*");
		}
		private static void GetDirTree(DirectoryInfo dr, string filter)
		{
		    FileInfo[] files = null;
		    DirectoryInfo[] subDirs = null;
		    try
		    {
			files = dr.GetFiles(filter + ".*");
		    }
		    catch(Exception) { }        
		    if (files != null)
		    {
			Parallel.ForEach(files, (FileInfo item) => { FilesBag.Add(item.Name); });
			subDirs = dr.GetDirectories();
			Parallel.ForEach(subDirs, (DirectoryInfo item) => { GetDirTree(item,filter); });
		    }
		}
		public static async Task GetFilesOnRootAsync(string filter)
		{
		    await Task.Run(() => {
			GetFilesOnRoot(filter);
		    });
		}
	    }
	}
