    public class ExportDirectory {
        public string Path { get; set; }
        public string Archive { get; set; }
        public List<string> Mail { get; set; }
        public ExportDirectory() {
            Mail = new List<string>();
        }
    }
