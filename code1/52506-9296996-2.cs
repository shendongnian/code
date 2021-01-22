    public string DirProject()
    {
        string DirDebug = System.IO.Directory.GetCurrentDirectory();
        string DirProject = DirDebug;
        for (int counter_slash = 0; counter_slash < 4; counter_slash++)
        {
            DirProject = DirProject.Substring(0, DirProject.LastIndexOf(@"\"));
        }
        return DirProject;
    }
