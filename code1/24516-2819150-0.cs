    using System.IO;
            
    public static string[] ExpandFilePaths(string[] args)
    {
        var fileList = new List<string>();
    
        foreach (var arg in args)
        {
            var substitutedArg = System.Environment.ExpandEnvironmentVariables(arg);
    
            var dirPart = Path.GetDirectoryName(substitutedArg);
            if (dirPart.Length == 0)
                dirPart = ".";
    
            var filePart = Path.GetFileName(substitutedArg);
    
            foreach (var filepath in Directory.GetFiles(dirPart, filePart))
                fileList.Add(filepath);
        }
    
        return fileList.ToArray();
    }
