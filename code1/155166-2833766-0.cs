    public string SearchFile (string path, string filename)
    {
        if (File.exists(path+filename)) return path;
        foreach(subdir in path)
        {
            string dir = Searchfile(subdirpath,filename);
            if (dir != "") return dir;
        }
    }
