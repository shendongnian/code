	public IEnumerable<string> FilterFiles(string path, params string[] exts) {
		return 
			exts.Select(x => "*." + x) // turn into globs
			.SelectMany(x => 
				Directory.EnumerateFiles(path, x)
				);
	}
