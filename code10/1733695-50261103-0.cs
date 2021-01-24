    public class SaleGroup
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public SaleFile File { get; set; }
    }
    public class SaleFile
    {
        public string Location { get; set; }
        public string FileType { get; set; }
        public string Destination { get; set; }
    }
