        private IEnumerable<String> FindAccessableFiles(string path, string file_pattern, bool recurse)
        {
            var list = new List<string>();
            if (File.Exists(path))
            {
                yield return path;
                yield break;
            }
            if (!Directory.Exists(path))
            {
                yield break;
            }
            if (null == file_pattern)
                file_pattern = "*." + required_extension;
            var top_directory = new DirectoryInfo(path);
            // Enumerate the files just in the top directory.
            var files = top_directory.EnumerateFiles(file_pattern).GetEnumerator();
            while (true)
            {
                FileInfo file = null;
                try
                {
                    if (files.MoveNext())
                        file = files.Current;
                    else
                        break;
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (PathTooLongException)
                {
                    continue;
                }
                yield return file.FullName;
            }
            if (!recurse)
                yield break;
            var dirs = top_directory.EnumerateDirectories("*").GetEnumerator();
            while (true)
            {
                DirectoryInfo dir = null;
                try
                {
                    if (dirs.MoveNext())
                        dir = dirs.Current;
                    else
                        break;
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (PathTooLongException)
                {
                    continue;
                }
                foreach (var subpath in FindAccessableFiles(dir.FullName, file_pattern, required_extension, recurse))
                    yield return subpath;
            }
        }
