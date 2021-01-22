	using System.IO;
	using System.Reflection;
	 
	namespace Konard.Helpers
	{
		public static partial class TemporaryFiles
		{
			private const string UserFilesListFilenamePrefix = ".used-temporary-files.txt";
			static private readonly object UsedFilesListLock = new object();
	 
			private static string GetUsedFilesListFilename()
			{
				return Assembly.GetEntryAssembly().Location + UserFilesListFilenamePrefix;
			}
	 
			private static void AddToUsedFilesList(string filename)
			{
				lock (UsedFilesListLock)
				{
					using (var writer = File.AppendText(GetUsedFilesListFilename()))
						writer.WriteLine(filename);
				}
			}
	 
			public static string UseNew()
			{
				var filename = Path.GetTempFileName();
				AddToUsedFilesList(filename);
				return filename;
			}
	 
			public static void DeleteAllPreviouslyUsed()
			{
				lock (UsedFilesListLock)
				{
					var usedFilesListFilename = GetUsedFilesListFilename();
	 
					if (!File.Exists(usedFilesListFilename))
						return;
	 
					using (var listFile = File.Open(usedFilesListFilename, FileMode.Open))
					{
						using (var reader = new StreamReader(listFile))
						{
							string tempFileToDelete;
							while ((tempFileToDelete = reader.ReadLine()) != null)
							{
								if (File.Exists(tempFileToDelete))
									File.Delete(tempFileToDelete);
							}
						}
					}
	 
					// Clean up
					using (File.Open(usedFilesListFilename, FileMode.Truncate)) { }
				}
			}
		}
	}
