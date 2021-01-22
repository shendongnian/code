    class PdfPage
    {
        public string content { get; set; }
        public List<PdfRow> rows { get; set; }
    }
    class PdfRow
    {
        public string content { get; set; }
        public List<string> words { get; set; }
    }
