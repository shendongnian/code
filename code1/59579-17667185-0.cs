        /// </remarks>
        public static IEnumerable<string> GetAllFiles(string path, Func<FileInfo, bool> checkFile = null)
        {
            string mask = Path.GetFileName(path);
            if (string.IsNullOrEmpty(mask))
                mask = "*.*";
            path = Path.GetDirectoryName(path);
            string[] files = Directory.GetFiles(path, mask, SearchOption.AllDirectories);
            foreach (string file in files)
            {
                if (checkFile == null || checkFile(new FileInfo(file)))
                    yield return file;
            }
        }
