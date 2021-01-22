    public static class Extensions
    {
        public static void CopyDirectory(this DirectoryInfo source, DirectoryInfo target)
        {
            if (!source.Exists) return;
            source.GetDirectories().ToList().ForEach(sourceChildDirectory =>
            {
                var path = Path.Combine(target.FullName, sourceChildDirectory.Name);
                if (!Directory.Exists(path))
                    CopyDirectory(sourceChildDirectory, new DirectoryInfo(path));
            });
            source.GetFiles().ToList().ForEach(file =>
                file.CopyTo(Path.Combine(target.FullName, file.Name), true));
        }
        public static void CopyDirectory(this DirectoryInfo source, string target)
        {
            CopyDirectory(source, new DirectoryInfo(target));
        }
    }
