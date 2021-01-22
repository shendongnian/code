        public static Dictionary<string, string> GetDetails(this FileInfo fi)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            Shell shl = new ShellClass();
            Folder folder = shl.NameSpace(fi.DirectoryName);
            FolderItem item = folder.ParseName(fi.Name);
            for (int i = 0; i < 150; i++)
            {
                string dtlDesc = folder.GetDetailsOf(null, i);
                string dtlVal = folder.GetDetailsOf(item, i);
                
                if (dtlVal == null || dtlVal == "")
                    continue;
                ret.Add(dtlDesc, dtlVal);
            }
            return ret;
        }
