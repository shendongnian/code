    public void CompareFiles(IList<string> firstFiles,
                             IList<string> secondFiles,
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
