        public static void FullDeleteDirectories(DirectoryInfo baseDir)
        {
            if (!baseDir.Exists)
                return;
            foreach (var enumerateDirectory in baseDir.EnumerateDirectories())
            {
                FullDeleteDirectories(enumerateDirectory);
            }
            baseDir.Delete(true);
        }
