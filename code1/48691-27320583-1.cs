    var exts = new[] { ".mp3", ".jpg" };
    public IEnumerable<string> FilterFiles(string path, params string[] exts) {
        return
            Directory
            .GetFiles(path, SearchOption.AllDirectories)
            .Where(file => !exts.Any(x => file.Extension.EndsWith(x, StringComparison.OrdinalIgnoreCase)));
    }
