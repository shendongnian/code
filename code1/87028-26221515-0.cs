    public string[] GetFilesFrom(string dir, string search_pattern, bool recursive)
    {
        List<string> files = new List<string>();
        string[] temp_files = new string[0];
        try { temp_files = Directory.GetFiles(dir, search_pattern, SearchOption.TopDirectoryOnly); }
        catch { }
        files.AddRange(temp_files);
        if (recursive)
        {
            string[] temp_dirs = new string[0];
            try { temp_dirs = Directory.GetDirectories(dir, search_pattern, SearchOption.TopDirectoryOnly); }
            catch { }
            for (int i = 0; i < temp_dirs.Length; i++)
                files.AddRange(GetFilesFrom(temp_dirs[i], search_pattern, recursive));
        }
        return files.ToArray();
    }
