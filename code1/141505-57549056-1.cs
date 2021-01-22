		var tests = new[] {
        Path.GetTempFileName(),
        Path.GetDirectoryName(Path.GetTempFileName()),
        "http://in.ter.net",
        "http://in.ter.net/",
        "http://in.ter.net/subfolder/",
        "http://in.ter.net/subfolder/filenoext",
        "http://in.ter.net/subfolder/file.ext",
        "http://in.ter.net/subfolder/file.ext?somequerystring=yes",
        Path.GetFileName(Path.GetTempFileName()),
        Path.Combine("subfolder", Path.GetFileName(Path.GetTempFileName()))};
		tests.Select(test =>
		{
			if (Uri.TryCreate(test, UriKind.Absolute, out var u))
			{
				return new { test, u.IsAbsoluteUri, u.IsFile };
			}
			return new { test, IsAbsoluteUri = false, IsFile = true };
		}
		).Dump();
And as extension methods:
csharp
        public static bool IsLocalAbsolutePath(this string input)
        {
            if (Uri.TryCreate(input, UriKind.Absolute, out var uri))
            {
                return uri.IsFile;
            }
            return false;
        }
        
        public static bool IsRemoteAbsolutePath(this string input)
        {
            if (Uri.TryCreate(input, UriKind.Absolute, out var uri))
            {
                return !uri.IsFile;
            }
            return false;
        }
