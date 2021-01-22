    class ExcelSearcher
    {
        private List<string> _fileNames;
        public ExcelSearcher(List<string> filenames)
        {
            _fileNames = filenames;
        }
        public List<string> GetExcelFiles(string dir, List<string> filenames = null)
        {
            string dirName = dir;
            var dirNames = new List<string>();
            if (filenames != null)
            {
                _fileNames.Concat(filenames);
            }
            try
            {
                foreach (string f in Directory.GetFiles(dirName))
                {
                    if (f.ToLower().Contains(".xls") || f.ToLower().Contains(".xlsx"))
                    {
                        _fileNames.Add(f);
                    }
                }
                dirNames = Directory.GetDirectories(dirName).ToList();
                foreach (string d in dirNames)
                {
                    GetExcelFiles(d, _fileNames);
                }
            }
            catch (Exception ex)
            {
                //Bam
            }
            return _fileNames;
        }
