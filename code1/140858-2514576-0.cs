	public static string SupportedFilesToDisplayString(string supportedFileTypes)
	{
		if (supportedFileTypes == null)
		{
			throw new ArgumentNullException("supportedFileTypes");
		}
		
        var fileTypes = supportedFileTypes.Split('|')
			.Select(s => string.Format("\"{0}\"", s));
        var lastFileType = fileTypes.Skip(fileTypes.Count() - 1).SingleOrDefault();
        var otherFileTypes = fileTypes.Take(fileTypes.Count() - 1);
        if (otherFileTypes.Any())
        {
            var otherString = String.Join(", ", otherFileTypes.ToArray());
            return string.Format("{0} and {1}", otherString, lastFileType);
        }
        else
        {
            return lastFileType;
        }
	}
