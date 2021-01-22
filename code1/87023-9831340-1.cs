    private IEnumerable<String> FindAccessableFiles(string path, string file_pattern, bool recurse)
    {
      IEnumerable<String> emptyList = new string[0];
      if (File.Exists(path))
        return new string[] { path };
      if (!Directory.Exists(path))
        return emptyList;
      var top_directory = new DirectoryInfo(path);
      // Enumerate the files just in the top directory.
      var files = top_directory.EnumerateFiles(file_pattern);
      var filesLength = files.Count();
      var filesList = Enumerable
                .Range(0, filesLength)
                .Select(i =>
                {
                  string filename = null;
                  try
                  {
                    var file = files.ElementAt(i);
                    filename = file.FullName;
                  }
                  catch (UnauthorizedAccessException)
                  {
                  }
                  catch (InvalidOperationException)
                  {
                        // ran out of entries
                  }
                  return filename;
                })
                .Where(i => null != i);
            if (!recurse)
              return filesList;
 
            var dirs = top_directory.EnumerateDirectories("*");
            var dirsLength = dirs.Count();
            var dirsList = Enumerable
                .Range(0, dirsLength)
                .SelectMany(i =>
                {
                  string dirname = null;
                  try
                  {
                    var dir = dirs.ElementAt(i);
                    dirname = dir.FullName;
                    return FindAccessableFiles(dirname, file_pattern, required_extension, recurse);
                  }
                  catch (UnauthorizedAccessException)
                  {
                  }
                  catch (InvalidOperationException)
                  {
                     // ran out of entries
                  }
                  return emptyList;
                })
      return Enumerable.Concat(filesList, dirsList);
    }
