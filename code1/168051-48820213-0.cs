    private bool IsValidPath(string path, bool exactPath = true)
	{
		bool isValid = true;
		try
		{
			string fullPath = Path.GetFullPath(path);
			if (exactPath)
			{
				string root = Path.GetPathRoot(path);
				isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
			}
			else
			{
				isValid = Path.IsPathRooted(path);
			}
		}
		catch(Exception ex)
		{
			isValid = false;
		}
		return isValid;
	}
