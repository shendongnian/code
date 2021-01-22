    static bool IsHidden(string p)
    {
     return p.Contains("Hidden");
    }
    DirectoryInfo directory = new DirectoryInfo(@"C:\temp");
    FileInfo[] files = directory.GetFiles();
    var filtered = files.Where(f => !IsHidden(File.GetAttributes(f).ToString()));
    foreach (var f in filtered)
    {
     Debug.WriteLine(f);
    }
