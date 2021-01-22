    private void DeleteDirectoryTree(List<string> directories)
    {
            // group directories by depth level and order it by level descending
            var data = directories.GroupBy(d => d.Split('\\'),
                d => d,
                (key, dirs) => new
                {
                    Level = key,
                    Directories = dirs.ToList()
                }).OrderByDescending(l => l.Level);
            var exceptions = new List<Exception>();
            var lockSource = new Object();
            foreach (var level in data)
            {
                Parallel.ForEach(level.Directories, dir =>
                {
                    var attrs = GetFileAttributes(dir);
                    attrs &= ~(uint)0x00000002; // hidden
                    attrs &= ~(uint)0x00000001; // read-only
                    SetFileAttributes(dir, attrs);
                    if (!RemoveDirectory(dir))
                    {
                        var msg = string.Format("Cannot remove directory {0}.{1}{2}", dir.Replace(@"\\?\UNC\", string.Empty), Environment.NewLine, new Win32Exception(Marshal.GetLastWin32Error()).Message);
                        lock (lockSource)
                        {
                            exceptions.Add(new Exception(msg));
                        }
                    }
                });
            }
            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
    }
