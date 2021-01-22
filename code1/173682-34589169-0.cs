    private DirectoryInfo ExecutingFolder
    {
        get
        {
            return new DirectoryInfo (
                System.IO.Path.GetDirectoryName (
                    System.Reflection.Assembly.GetExecutingAssembly().Location));
        }
    }
