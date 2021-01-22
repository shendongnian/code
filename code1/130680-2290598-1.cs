    // Get the file names and instantiate our helper class
    List<IEnumerator<string>> files = Directory.GetFiles(@"C:\temp\files", "*.txt").Select(file => new MergeFile(file)).Cast<IEnumerator<string>>().ToList();
    List<string> result = new List<string>();
    IEnumerator<string> next = null;
    while (true)
    {
        bool done = true;
        // loop over the helpers
        foreach (var mergeFile in files)
        {
            done = false;
            if (next == null || string.Compare(mergeFile.Current, next.Current) < 1)
            {
                next = mergeFile;
            }
        }
        if (done) break;
        result.Add(next.Current);
        if (!next.MoveNext())
        {
            // file is exhausted, dispose and remove from list
            next.Dispose();
            files.Remove(next);
            next = null;
        }
    }
