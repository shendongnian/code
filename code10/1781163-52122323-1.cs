    public struct DatedExcelOutput
    {
        public string FullName {  get; }
        public string Name { get; }
        public DateTime CreationDate { get; }
        public DatedExcelOutput(string fileName)
        {
            FullName = fileName;
            Name = getName();
            CreationDate = parseDate();
        }
    }
