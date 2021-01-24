    public static string GetFilename()
    {
        var dlg = new OpenFileDialog();
        var result = dlg.ShowDialog();
        var filename = dlg.FileName;
    
        return filename;
    }
    
    public static void Main()
    {
        var userChosenFile = GetFilename();
        var aDifferentChosenFile = GetFilename();
        var yetAnotherChosenFile = GetFilename();
    }
    
