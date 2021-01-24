    public struct DatedExcelOutput
    {
        public string FullName {  get; }
        public string Name { get; }
        public DateTime CreationDate { get; }
        public DatedExcelOutput(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));
            if (System.IO.File.Exists(fileName))
                throw new System.IO.FileNotFoundException(nameof(fileName));
            FullName = fileName;
            Name = getName();
            CreationDate = parseDate();
        }
    }
