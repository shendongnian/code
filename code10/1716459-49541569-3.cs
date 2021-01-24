    public (double, string) AdjustFileSize(long fileSizeInBytes)
    {
        var names = {"BYTES", "KB", "MB", "GB"};
        double sizeResult = fileSizeInBytes * 1.0;
        int nameIndex = 0;
        while (sizeResult > 1024 && nameIndex < names.Length)
        {
            sizeResult /= 1024; 
            nameIndex++;
        }
        return (sizeResult, names[nameIndex]);
    }
