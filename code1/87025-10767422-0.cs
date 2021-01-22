     static List<string> SearchFiles(string pattern)
        {
            var result = new List<string>();
            foreach (string drive in Directory.GetLogicalDrives())
            {
                Console.WriteLine("searching " + drive);
                var files = FindAccessableFiles(drive, pattern, true);
                Console.WriteLine(files.Count().ToString() + " files found.");
                result.AddRange(files);
            }
            return result;
        }
        private static IEnumerable<String> FindAccessableFiles(string path, string file_pattern, bool recurse)
        {
            Console.WriteLine(path);
            var list = new List<string>();
            var required_extension = "mp4";
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
            IEnumerator<FileInfo> files;
            try
            {
                files = top_directory.EnumerateFiles(file_pattern).GetEnumerator();
            }
            catch (Exception ex)
            {
                files = null;
            }
            while (true)
            {
                FileInfo file = null;
                try
                {
                    if (files != null && files.MoveNext())
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
            IEnumerator<DirectoryInfo> dirs;
            try
            {
                dirs = top_directory.EnumerateDirectories("*").GetEnumerator();
            }
            catch (Exception ex)
            {
                dirs = null;
            }
            
            while (true)
            {
                DirectoryInfo dir = null;
                try
                {
                    if (dirs != null && dirs.MoveNext())
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
                foreach (var subpath in FindAccessableFiles(dir.FullName, file_pattern, recurse))
                    yield return subpath;
            }
        }
