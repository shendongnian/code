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
				string pathA = Console.ReadLine();
				Console.Write("Write the path of the new file folder: ");
				string pathB = Console.ReadLine();
				Console.WriteLine("Press Enter to continue:");
				List<string> folderA = new List<string>();
				foreach (string filePath in Directory.GetFiles(pathA))
				{
					folderA.Add(Path.GetFileName(filePath));
				}
				List<string> folderB = new List<string>();
				foreach (string filePath in Directory.GetFiles(pathB))
				{
					folderB.Add(Path.GetFileName(filePath));
				}
				Console.Write("New files in folder" + pathA + " : ");
				Print(folderA, folderB);
				Console.WriteLine("------------------------------------");
				Console.Write("New files in folder" + pathB + " : ");
				Print(folderB, folderA);
				Console.Read();
			}
			static void Print(List<string> lstA, List<string> lstB)
			{
				foreach (string fileName in lstA)
				{
					if (!lstB.Contains(fileName))
					{
						Console.Out.WriteLine(fileName);
					}
				}
			}
		}
	}
