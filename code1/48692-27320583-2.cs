    var exts = new[] { ".mp3", ".jpg" };
    public IEnumerable<string> FilterFiles(string path, params string[] exts) {
        return
            Directory
            .GetFiles(path)
            .Where(file => !exts.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase)));
    }
