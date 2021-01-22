    private static bool IsExeFile(string path)
    {
        var twoBytes = new byte[2];
        using(var fileStream = File.Open(path, FileMode.Open))
        {
            fileStream.Read(twoBytes, 0, 2);
        }
        return Encoding.UTF8.GetString(twoBytes) == "MZ";
    }
