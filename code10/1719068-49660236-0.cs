    static IEnumerable<string> ResolveDirectories(string path) {
        if (path.Contains("*") || path.Contains("?")) {
            // we have a wildcard,
            // resolve it to absolute path if necessary
            if (!Path.IsPathRooted(path))
                path = Path.Combine(Directory.GetCurrentDirectory(), path);
            // resolve .. stuff if any
            path = new Uri(Path.Combine(Directory.GetCurrentDirectory(), path)).AbsolutePath;
            // split with regex above, only on first match (2 parts)
            var parts = new Regex(@"[\\/](?=[^\\/]*[\*?])").Split(path, 2);
            var searchRoot = parts[0];                
            var searchPatterns = parts[1].Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            foreach (var dir in ResolveWildcards(searchRoot, searchPatterns))
                yield return dir;                
        }
        else {
            // this should work with "../.." type of paths too, will resolve relative to current directory
            // so no processing is necessary
            if (Directory.Exists(path)) {
                yield return path;
            }
            else {
                // invalid directory?
            }
        }
    }
    static IEnumerable<string> ResolveWildcards(string searchRoot, string [] searchPatterns) {
        // if we have path C:\an\abolu*e\dir\with\wild*cards*
        // search root is C:\an
        // and patterns are: [abolu*e, dir, with, wild*cards*]
        if (Directory.Exists(searchRoot)) {
            // use next pattern to search in a search root
            var next = searchPatterns[0];
            // leave the rest for recursion
            var rest = searchPatterns.Skip(1).ToArray();
            foreach (var dir in Directory.EnumerateDirectories(searchRoot, next, SearchOption.AllDirectories)) {
                // if nothing left (last pattern) - return it
                if (rest.Length == 0)
                    yield return dir;
                else {
                    // otherwise search with rest patterns in freshly found directory
                    foreach (var sub in ResolveWildcards(dir, rest))
                        yield return sub;
                }
            }
        }
    }
