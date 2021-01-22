    public static class Extensions
    {
        public static void CopyTo(this DirectoryInfo source, DirectoryInfo target)
        {
            if (!source.Exists) return;
            if (!target.Exists) target.Create();
            foreach (var sourceChildDirectory in source.GetDirectories())
            {
                var path = Path.Combine(target.FullName, sourceChildDirectory.Name);
                if (!Directory.Exists(path))
                    CopyTo(sourceChildDirectory, new DirectoryInfo(path));
            }
            foreach (var sourceFile in source.GetFiles())
                sourceFile.CopyTo(Path.Combine(target.FullName, sourceFile.Name), true);
        }
        public static void CopyTo(this DirectoryInfo source, string target)
        {
            CopyTo(source, new DirectoryInfo(target));
        }
    }
