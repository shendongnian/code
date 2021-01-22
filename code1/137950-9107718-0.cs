    using Shell32;
    public static class Extension
    {
        public static string GetLength(this FileInfo info)
        {
            var shell = new ShellClass();
            var folder = shell.NameSpace(info.DirectoryName);
            var item = folder.ParseName(info.Name);
            return folder.GetDetailsOf(item, 27);
        }
    }
