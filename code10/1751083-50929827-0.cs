    public static class FileEx
    {
        public static Func<string, IEnumerable<string>> EnumerateFiles { set; get; }
           = Directory.EnumerateFiles;
    }
