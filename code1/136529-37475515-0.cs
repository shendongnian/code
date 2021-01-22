        SearchOption sopt = SearchOption.AllDirectories;
        List<String> listFiles = new List<string>();
        List<DirectoryInfo> dirs2scan = new List<DirectoryInfo>();
        dirs2scan.Add(new DirectoryInfo(fromPath) );
        for( ; dirs2scan.Count != 0; )
        {
            int scanIndex = dirs2scan.Count - 1;        // Try to preserve somehow alphabetic order which GetFiles returns 
                                                        // by scanning though last directory.
            FileInfo[] filesInfo = dirs2scan[scanIndex].GetFiles(pattern, SearchOption.TopDirectoryOnly);
            foreach (FileInfo fi in filesInfo)
            {
                if (bNoHidden && fi.Attributes.HasFlag(FileAttributes.Hidden))
                    continue;
                listFiles.Add(fi.FullName);
            }
            if( sopt != SearchOption.AllDirectories )
                break;
            foreach (DirectoryInfo dir in dirs2scan[scanIndex].GetDirectories("*", SearchOption.TopDirectoryOnly))
            {
                if (bNoHidden && dir.Attributes.HasFlag(FileAttributes.Hidden))
                    continue;
                        
                dirs2scan.Add(dir);
            }
            dirs2scan.RemoveAt(scanIndex);
        }
