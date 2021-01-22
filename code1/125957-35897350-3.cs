    private void SearchAndDelete(string path)
    {
        var fd = new WIN32_FIND_DATA();
        var found = false;
        var handle = IntPtr.Zero;
        var invalidHandle = new IntPtr(-1);
        var fileAttributeDir = 0x00000010;
        var filesToRemove = new List<string>();
        try
        {
            handle = FindFirsFile(path + @"\*", ref fd);
            if (handle == invalidHandle) return;
            do
            {
                var current = fd.cFileName;
                if (((int)fd.dwFileAttributes & fileAttributeDir) != 0)
                {
                    if (current != "." && current != "..")
                    {
                        var newPath = Path.Combine(path, current);
                        SearchAndDelete(newPath);
                    }
                }
                else
                {
                    filesToRemove.Add(Path.Combine(path, current));
                }
                found = FindNextFile(handle, ref fd);
            } while (found);
        }
        finally
        {
            FindClose(handle);
        }
        try
        {
            object lockSource = new Object();
            var exceptions = new List<Exception>();
            Parallel.ForEach(filesToRemove, file, =>
            {
                var attrs = GetFileAttributes(file);
                attrs &= ~(uint)0x00000002; // hidden
                attrs &= ~(uint)0x00000001; // read-only
                SetFileAttributes(file, attrs);
                if (!DeleteFile(file))
                {
                    var msg = string.Format("Cannot remove file {0}.{1}{2}", file.Replace(@"\\?\UNC", @"\"), Environment.NewLine, new Win32Exception(Marshal.GetLastWin32Error()).Message);
                    lock(lockSource)
                    {
                        exceptions.Add(new Exceptions(msg));
                    }
                }
            });
            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
        var dirAttr = GetFileAttributes(path);
        dirAttr &= ~(uint)0x00000002; // hidden
        dirAttr &= ~(uint)0x00000001; // read-only
        SetfileAttributtes(path, dirAttr);
        if (!RemoveDirectory(path))
        {
            throw new Exception(new Win32Exception(Marshal.GetLAstWin32Error()));
        }
    }
