	using System;
	using System.IO;
	public static class FileSystemInfoExtensions
	{
		public static void Rename(this FileSystemInfo item, string newName)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			FileInfo fileInfo = item as FileInfo;
			if (fileInfo != null)
			{
				fileInfo.Rename(newName);
				return;
			}
			DirectoryInfo directoryInfo = item as DirectoryInfo;
			if (directoryInfo != null)
			{
				directoryInfo.Rename(newName);
				return;
			}
			throw new ArgumentException("Item", "Unexpected subclass of FileSystemInfo " + item.GetType());
		}
		public static void Rename(this FileInfo file, string newName)
		{
			// Validate arguments.
			if (file == null)
			{
				throw new ArgumentNullException("file");
			}
			else if (newName == null)
			{
				throw new ArgumentNullException("newName");
			}
			else if (newName.Length == 0)
			{
				throw new ArgumentException("The name is empty.", "newName");
			}
			else if (newName.IndexOf(Path.DirectorySeparatorChar) >= 0
				|| newName.IndexOf(Path.AltDirectorySeparatorChar) >= 0)
			{
				throw new ArgumentException("The name contains path separators. The file would be moved.", "newName");
			}
			// Rename file.
			string newPath = Path.Combine(file.DirectoryName, newName);
			file.MoveTo(newPath);
		}
		public static void Rename(this DirectoryInfo directory, string newName)
		{
			// Validate arguments.
			if (directory == null)
			{
				throw new ArgumentNullException("directory");
			}
			else if (newName == null)
			{
				throw new ArgumentNullException("newName");
			}
			else if (newName.Length == 0)
			{
				throw new ArgumentException("The name is empty.", "newName");
			}
			else if (newName.IndexOf(Path.DirectorySeparatorChar) >= 0
				|| newName.IndexOf(Path.AltDirectorySeparatorChar) >= 0)
			{
				throw new ArgumentException("The name contains path separators. The directory would be moved.", "newName");
			}
			// Rename directory.
			string newPath = Path.Combine(directory.Parent.FullName, newName);
			directory.MoveTo(newPath);
		}
	}
