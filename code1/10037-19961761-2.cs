	public IEnumerable<string> FilterFiles(string path, params string[] exts) {
		return
			Directory
			.EnumerateFiles(path, "*.*")
			.Where(file => exts.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase)));
	}
