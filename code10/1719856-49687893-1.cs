    // key    - what to find (file name without directory, e.g. "abc.txt")
    // value  - what to substitute (full path name, e.g. "c:\test\abc.txt") 
    // StringComparer.OrdinalIgnoreCase - case insensitive keys, i.e. "abc.txt" == "ABC.txt"
    Dictionary<string, string> substitutes = optimizelist
      .ToDictionary(item => Path.GetFileName(item),
                    item => item,
                    StringComparer.OrdinalIgnoreCase);
    for (int i = 0; i < Filelist.Count; i++)
      // if we have a substitution (i.e. a better file path)...
      if (optimizelist.TryGetValue(Path.GetFileName(Filelist[i]), out var optimalFile))
        Filelist[i] = optimalFile; // <- substitute with optimalFile 
