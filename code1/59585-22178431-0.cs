    // call this like so: GetXMLFiles("Platypus", "C:\\");
    public static List<string> GetXMLFiles(string fileType, string dir)
    {
        string dirName = dir; 
        var fileNames = new List<String>();
        try
        {
            foreach (string f in Directory.GetFiles(dirName))
            {
                if ((f.Contains(fileType)) && (f.Contains(".XML")))
                {
                    fileNames.Add(f);
                }
            }
            foreach (string d in Directory.GetDirectories(dirName))
            {
                GetXMLFiles(fileType, d);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        return fileNames;
    }
