    public static class KnownFoldersExtensions
    {
        public static string Path(this Environment.SpecialFolder folder)
        {
            var path = Environment.GetFolderPath(folder);
            if (string.IsNullOrEmpty(path))
            {
                throw new PlatformNotSupportedException();
            }
            return path;
        }
    }
