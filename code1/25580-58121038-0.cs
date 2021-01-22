        /// <summary>
        /// Split a directory in its components.
        /// Input e.g: a/b/c/d.
        /// Output: d, c, b, a.
        /// </summary>
        /// <param name="Dir"></param>
        /// <returns></returns>
        public static IEnumerable<string> DirectorySplit(this DirectoryInfo Dir)
        {
            while (Dir != null)
            {
                yield return Dir.Name;
                Dir = Dir.Parent;
            }
        }
