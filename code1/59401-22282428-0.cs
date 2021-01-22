        public static void FullDeleteDirectories(DirectoryInfo baseDir)
        {
            foreach (var enumerateDirectory in baseDir.EnumerateDirectories())
            {
                FullDeleteDirectories(enumerateDirectory);
            }
            baseDir.Delete(true);
        }
