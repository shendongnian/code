	using System;
	using System.Collections.Generic;
	using System.IO;
	namespace so_cp__r
	{
		class Program
		{
			static void Main(string[] args)
			{
				Console.WriteLine("Enter path from where you want to copy:");
				List<DirectoryInfo> fromDirs = new List<DirectoryInfo>();
				DirectoryInfo dir = new FileInfo(Console.ReadLine()).Directory;
				while (dir != null)
				{
					fromDirs.Add(dir);
					dir = dir.Parent;
				}
				for (int i = 0; i < fromDirs.Count; i++)
					Console.WriteLine("{0}: {1}", i, fromDirs[i].FullName);
				Console.WriteLine("From which of these dirs do you want to start?");
				DirectoryInfo fromDir = fromDirs[int.Parse(Console.ReadLine())];
				Console.WriteLine("Where do you want to copy?");
				DirectoryInfo toDir = new DirectoryInfo(Console.ReadLine());
				recursive_copy(fromDir, toDir);
			}
			static void recursive_copy(DirectoryInfo fromDir, DirectoryInfo toDir)
			{
				DirectoryInfo child = toDir.CreateSubdirectory(fromDir.Name);
				foreach (FileInfo file in fromDir.GetFiles())
					file.CopyTo(child.FullName + Path.DirectorySeparatorChar + file.Name);
				foreach (DirectoryInfo dir in fromDir.GetDirectories())
					recursive_copy(dir, child);
			}
		}
	}
