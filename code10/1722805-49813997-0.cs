    static void Main(string[] args)
    {
        var filename1 = ReplaceFileName("filenameMMddyyyy");
        var filename2 = ReplaceFileName("filename_yyyy");
        var filename3 = ReplaceFileName("filenameddMM");
    }
    private static string ReplaceFileName(string filename)
    {
        var dateTime = DateTime.Now;
        filename = filename.Replace("dd", dateTime.ToString("dd"));
        filename = filename.Replace("MM", dateTime.ToString("MM"));
        filename = filename.Replace("yyyy", dateTime.ToString("yyyy"));
        return filename;
    }
