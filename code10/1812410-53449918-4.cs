    public class ContractFile : File
    {
        public string Partner { get; set; }
        public Date CreationDate { get; set; }
        public string Remarks { get; set; }
        public string Filename { get; set; }
    }
    ...
    public class File
    {
        public String File { get; set; }
        public Stream Data { get; set; }
    }
