    //global var
    string startDir = @"D:\test";
    void Scan(string dir)
    {
            //directory not empty
            if (Directory.GetFileSystemEntries(dir).Length > 0)
            {
                foreach (string subdir in Directory.GetDirectories(dir))
                    Scan(subdir);
            }
            //directory empty so delete it.
            else
            {
                //delete dir
                Directory.Delete(dir);
                //scan previous directory again because it can be empty now
                string prevDir = dir.Substring(0, dir.LastIndexOf("\\"));
                if (prevDir.Length >= startDir.Length)
                    Scan(prevDir);
            }
    }
    //call like this
    Scan(startDir);
