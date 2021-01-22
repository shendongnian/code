        public static IEnumerable<string> FindFiles (string path, string filter = "", int depth = int.MaxValue) {
            DirectoryInfo di = new DirectoryInfo(path);
            IEnumerable<string> results = (! string.IsNullOrEmpty(filter) ? di.GetFiles(filter) : di.GetFiles()).Select(f => f.FullName);
            if (depth > 0) {
                results = results.Concat(di.GetDirectories().SelectMany(d => FindFiles(d.FullName, filter, depth - 1)));
            }
            return results;
        }
