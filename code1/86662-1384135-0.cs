    public static class FileSystemExtensions
    {
        public static long GetDirectoryBytesSize(
            this DirectoryInfo info);
        public static string FormatDirectoryBytesSize(
            this DirectoryInfo info, FileSizeFormat format);
    }
    public enum FileSizeFormat
    {
        KiloByte,
        MegaByte,
    }
