    var files = (string[])e.Data.GetData(DataFormats.FileDrop);
    var importList = new List<string>();
    foreach (string s in files)
    {
        if (Directory.Exists(s))
            foreach (var f in Directory.GetFiles(s, "*.*", SearchOption.AllDirectories))
                importList.Add(f);
        else if (File.Exists(s))
            importList.Add(s);
    }
