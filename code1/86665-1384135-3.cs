    public static class FileSystemSize
    {
        public static long GetDirectoryBytesSize(string path);
    }
    public static class NumberExtensions
    {
        public static string FormatAsFileSize(
            this long fileSize, FileSizeFormat format);
    }
