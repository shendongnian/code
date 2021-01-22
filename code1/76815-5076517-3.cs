		private string GetFileSystemCasing(string path)
		{
			if (Path.IsPathRooted(path))
			{
				path = path.TrimEnd(Path.DirectorySeparatorChar); // if you type c:\foo\ instead of c:\foo
				try
				{
					string name = Path.GetFileName(path);
					if (name == "") return path.ToUpper() + Path.DirectorySeparatorChar; // root reached
					string parent = Path.GetDirectoryName(path); // retrieving parent of element to be corrected
					parent = GetFileSystemCasing(parent); //to get correct casing on the entire string, and not only on the last element
					DirectoryInfo diParent = new DirectoryInfo(parent);
					FileSystemInfo[] fsiChildren = diParent.GetFileSystemInfos(name);
					FileSystemInfo fsiChild = fsiChildren.First();
					return fsiChild.FullName; // coming from GetFileSystemImfos() this has the correct case
				}
				catch (Exception ex) { Trace.TraceError(ex.Message); throw new ArgumentException("Invalid path"); }
				return "";
			}
			else throw new ArgumentException("Absolute path needed, not relative");
		}
