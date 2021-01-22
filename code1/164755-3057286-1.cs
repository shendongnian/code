    class RegExFileFilter : IFileFilter
    
    {
        #region IFileFilter Members
    
        public string GetFilterName()
        {
            return "RegExFilter";
        }
    
        public string GetFilterReadableName()
        {
            return "RegEx Filter";
        }
    
        public FileInfo[] GetFilteredFiles(string path, string filter)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] fullFileList = d.GetFiles();
            List<FileInfo> filteredList = new List<FileInfo>();
            Regex rgx = new Regex(filter);
            foreach (FileInfo fi in fullFileList)
            {
                if (rgx.IsMatch(fi.Name))
                {
                    filteredList.Add(fi);
                }
            }
            return filteredList.ToArray();
        }
    
        #endregion
    }
    class TextFileFilter : IFileFilter
    {
        #region IFileFilter Members
    
        public string GetFilterName()
        {
            return "TextFilter";
        }
    
        public string GetFilterReadableName()
        {
            return "Text Filter";
        }
    
        public FileInfo[] GetFilteredFiles(string path, string filter)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] fi = d.GetFiles(filter);
            return fi;
        }
    
        #endregion
    }
    class NoFileFilter : IFileFilter
    {
        #region IFileFilter Members
    
        public string GetFilterName()
        {
            return "TextFilter";
        }
    
        public string GetFilterReadableName()
        {
            return "Text Filter";
        }
    
        public FileInfo[] GetFilteredFiles(string path, string filter)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] fi = d.GetFiles(filter);
            return fi;
        }
    
        #endregion
    }
