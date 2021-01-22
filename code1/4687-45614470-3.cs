    public static class Extensions
    {
        public static void CopyTo(this DirectoryInfo source, DirectoryInfo target, bool overwiteFiles = true)
        {
            if (!source.Exists) return;
            if (!target.Exists) target.Create();
            foreach (var sourceChildDirectory in source.GetDirectories())
                CopyTo(sourceChildDirectory, new DirectoryInfo(Path.Combine(target.FullName, sourceChildDirectory.Name)));
            foreach (var sourceFile in source.GetFiles())
                sourceFile.CopyTo(Path.Combine(target.FullName, sourceFile.Name), overwiteFiles);
        }
        public static void CopyTo(this DirectoryInfo source, string target, bool overwiteFiles = true)
        {
            CopyTo(source, new DirectoryInfo(target), overwiteFiles);
        }
    }
