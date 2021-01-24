	using System;
	using System.Collections.Generic;
	using System.IO;
	namespace ConsoleApplication1
	{
		class Program
		{
			static void Main(string[] args)
			{
				Console.Write("Write the path of the old file folder: ");
				string path = Console.ReadLine();
				Console.Write("Write the path of the new file folder: ");
				string pathTwo = Console.ReadLine();
				Console.WriteLine("Press Enter to continue:");
				List<string> filePaths = new List<string>();
				filePaths.AddRange(Directory.GetFiles(path));
				List<string> filePathsTwo = new List<string>();
				filePathsTwo.AddRange(Directory.GetFiles(pathTwo));
				Console.Write("New files in folder" + path + " : ");
				Print(filePaths, filePathsTwo);
				Console.Write("New files in folder" + filePathsTwo + " : ");
				Print(filePathsTwo, filePaths);
				Console.Read();
			}
			static void Print(List<string> lstOld, List<string> lstnew)
			{
				foreach (string old in lstOld)
				{
					if (!lstnew.Contains(old))
					{
						Console.Out.WriteLine(old);
					}
				}
			}
		}
	}
