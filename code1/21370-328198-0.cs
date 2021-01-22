    public static bool HasExtension(this FileInfo file)
    {
        var ext = file.Extension.StartsWith(".") ? file.Extension.Substring(1) 
                                                 : file.Extension;
        return Enum.GetNames(typeof(FileExtensions))
                   .Any(f => f.Equals(ext));
    }
