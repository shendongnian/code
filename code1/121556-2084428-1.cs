    public void CompareFiles(IEnumerable<string> firstFiles,
                             IEnumerable<string> secondFiles,
                             Action<string, string> comparison)
    {
        foreach (string file1 in firstFiles)
        {
            foreach (string file2 in secondFiles)
            {
                comparison(file1, file2);
            }
        }
    }
