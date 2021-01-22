        /// <summary>
        /// Creates the unique temporary directory.
        /// </summary>
        /// <returns>
        /// Directory path.
        /// </returns>
        public string CreateUniqueTempDirectory()
        {
            var uniqueTempDir = Path.GetFullPath(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));
            Directory.CreateDirectory(uniqueTempDir);
            return uniqueTempDir;
        }
