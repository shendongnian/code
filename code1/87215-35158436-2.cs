	/// <summary>
	/// Whether the <paramref name="path"/> is a folder (existing or not); 
	/// optionally assume that if it doesn't "look like" a file then it's a directory.
	/// </summary>
	/// <param name="path">Path to check</param>
	/// <param name="assumeDneLookAlike">If the <paramref name="path"/> doesn't exist, does it at least look like a directory name?  As in, it doesn't look like a file.</param>
	/// <returns><c>True</c> if a folder/directory, <c>false</c> if not.</returns>
	public static bool IsFolder(string path, bool assumeDneLookAlike = true)
	{
		// http://stackoverflow.com/questions/1395205/better-way-to-check-if-path-is-a-file-or-a-directory
		// turns out to be about the same as http://stackoverflow.com/a/19596821/1037948
		// check in order of verisimilitude
		// exists or ends with a directory separator -- files cannot end with directory separator, right?
		if (Directory.Exists(path)
			// use system values rather than assume slashes
			|| path.EndsWith("" + Path.DirectorySeparatorChar)
			|| path.EndsWith("" + Path.AltDirectorySeparatorChar))
			return true;
		// if we know for sure that it's an actual file...
		if (File.Exists(path))
			return false;
		// if it has an extension it should be a file, so vice versa
		// although technically directories can have extensions...
		if (!Path.HasExtension(path) && assumeDneLookAlike)
			return true;
		
		// only works for existing files, kinda redundant with `.Exists` above
		//if( File.GetAttributes(path).HasFlag(FileAttributes.Directory) ) ...; 
		// no idea -- could return an 'indeterminate' value (nullable bool)
		// or assume that if we don't know then it's not a folder
		return false;
	}
