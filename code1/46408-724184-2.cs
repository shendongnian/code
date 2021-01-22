         static List<Info> RecursiveScan2(string directory) {
            IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
            WIN32_FIND_DATAW findData;
            IntPtr findHandle;
            var info = new List<Info>();
            // please note that the following line won't work if you try this on a network folder, like \\Machine\C$
            // simply remove the \\?\ part in this case or use \\?\UNC\ prefix
            findHandle = FindFirstFileW(directory + @"\*", out findData);
            if (findHandle != INVALID_HANDLE_VALUE) {
                
                do {
                    if (findData.cFileName == "." || findData.cFileName == "..") continue;
                    bool isDir = false;
                    if ((findData.dwFileAttributes & FileAttributes.Directory) != 0) {
                        isDir = true;
                     
                        string subdirectory = directory + (directory.EndsWith(@"\") ? "" : @"\") +
                            findData.cFileName;
                        info.AddRange(RecursiveScan2(subdirectory));
                        
                    }
                    info.Add(new Info()
                    {
                        CreatedDate = DateTime.FromFileTimeUtc(findData.ftCreationTime.dwHighDateTime << 32 + findData.ftCreationTime.dwLowDateTime),
                        ModifiedDate = DateTime.FromFileTimeUtc(findData.ftLastWriteTime.dwHighDateTime << 32 + findData.ftLastWriteTime.dwLowDateTime), 
                        IsDirectory = isDir,
                        Path = findData.cFileName
                    });
                }
                while (FindNextFile(findHandle, out findData));
                FindClose(findHandle);
            }
            return info;
        }
