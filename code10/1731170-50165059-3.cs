    static IEnumerable<string> DoSomething(KeyValuePair<string, string>[] dir) {
        char[] PathSeparators = new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };
        // some local utility functions
        // split a path into an array of its components [drive,dir1,dir2,...]
        string[] PathComponents(string p) => p.Split(PathSeparators, StringSplitOptions.RemoveEmptyEntries);
        // Combine path components back into a canonical path
        string PathCombine(IEnumerable<string> p) => p.Join(Path.DirectorySeparatorChar);
        // return all distinct paths that are depth deep, truncating longer paths
        IEnumerable<string> PathsAtDepth(IEnumerable<(string Path, string[] Components, string Filename)> dirs, int depth)
            => dirs.Select(pftuple => pftuple.Components)
                   .Where(pa => pa.Length > depth)
                   .Select(pa => PathCombine(pa.Slice(0, depth + 1)))
                   .Distinct();
    
        // split path into components clean up trailing PathSeparators
        var cleanDirs = dir.Select(kvp => (Path: kvp.Key.TrimEnd(PathSeparators), Components: PathComponents(kvp.Key), Filename: kvp.Value));
        // find the longest path
        var maxDepth = cleanDirs.Select(pftuple => pftuple.Components.Length).Max();
        // ignoring drive, gather all paths at each length and the files beneath them
        var pfl = Enumerable.Range(1, maxDepth)
                            .SelectMany(d => PathsAtDepth(cleanDirs, d) // get paths down to depth d
                                 .Select(pathAtDepth => new {
                                    Depth = d,
                                    Path = pathAtDepth,
                                    // gather all filenames for pathAtDepth d
                                    Files = cleanDirs.Where(pftuple => pftuple.Path == pathAtDepth)
                                                     .Select(pftuple => pftuple.Filename)
                                                     .ToList()
                                }))
                                .OrderBy(dpef => dpef.Path); // sort into tree
        // convert each entry into its directory path end followed by all files beneath that directory
        var stringTree = pfl.SelectMany(dpf => dpf.Files.Select(f => ' '.Repeat(4 * (dpf.Depth - 1)) + $"({f})")
                                                        .Prepend(' '.Repeat(4 * (dpf.Depth - 1)) + Path.GetFileName(dpf.Path)));
    
        return stringTree;
    }
