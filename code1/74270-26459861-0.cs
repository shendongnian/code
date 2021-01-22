		public static class FileInfoExt
		{
			public static FileInfo DeDupue(this FileInfo f)
			{
				string path = f.FullName;
				string directory = Path.GetDirectoryName(path);
				string filename = Path.GetFileNameWithoutExtension(path);
				string extension = Path.GetExtension(path);
				string newFullPath = path;
				IEnumerable<string> files = new DirectoryInfo(directory)
					.EnumerateFiles().Select(r => r.FullName);
				for (int i = 1; files.Contains(newFullPath); i++)
				{
					string newFilename = string.Format(
						"{0}({1}){2}",
						filename,
						i,
						extension);
					newFullPath = Path.Combine(directory, newFilename);
				}
				return new FileInfo(newFullPath);
			}
		}
