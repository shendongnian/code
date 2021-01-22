    using System;
    using System.IO;
    using System.Collections.Generic;
    namespace DirectoryWalker
    {
        public class DirectoryWalker : IEnumerable<string>
        {
            private string _seedPath;
            Func<string, bool> _directoryFilter, _fileFilter;
            public DirectoryWalker(string seedPath) : this(seedPath, null, null)
            {
            }
            public DirectoryWalker(string seedPath, Func<string, bool> directoryFilter, Func<string, bool> fileFilter)
            {
                if (seedPath == null)
                    throw new ArgumentNullException(seedPath);
                _seedPath = seedPath;
                _directoryFilter = directoryFilter;
                _fileFilter = fileFilter;
            }
            public IEnumerator<string> GetEnumerator()
            {
                Queue<string> directories = new Queue<string>();
                directories.Enqueue(_seedPath);
                Queue<string> files = new Queue<string>();
                while (files.Count > 0 || directories.Count > 0)
                {
                    if (files.Count > 0)
                    {
                        yield return files.Dequeue();
                    }
                    if (directories.Count > 0)
                    {
                        string dir = directories.Dequeue();
                        string[] newDirectories = Directory.GetDirectories(dir);
                        string[] newFiles = Directory.GetFiles(dir);
                        foreach (string path in newDirectories)
                        {
                            if (_directoryFilter == null || _directoryFilter(path))
                                directories.Enqueue(path);
                        }
                        foreach (string path in newFiles)
                        {
                            if (_fileFilter == null || _fileFilter(path))
                                files.Enqueue(path);
                        }
                    }
                }
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
