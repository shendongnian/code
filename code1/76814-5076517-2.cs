		private string GetFileSystemCasing(string path)
		{
			if (Path.IsPathRooted(path))
			{
				path = path.TrimEnd(Path.DirectorySeparatorChar);
				try
				{
					string name = Path.GetFileName(path);
					if (name == "") return path.ToUpper() + Path.DirectorySeparatorChar; // root reached
					string parent = Path.GetDirectoryName(path);
					parent = GetFileSystemCasing(parent);
					DirectoryInfo diParent = new DirectoryInfo(parent);
					FileSystemInfo[] fsiChildren = diParent.GetFileSystemInfos(name);
					FileSystemInfo fsiChild = fsiChildren.First();
					return fsiChild.FullName;
				}
				catch (Exception ex) { Trace.TraceError(ex.Message); throw new ArgumentException("Invalid path"); }
				return "";
			}
			else throw new ArgumentException("Absolute path needed, not relative");
		}
