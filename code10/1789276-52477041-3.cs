    public class Xfile
    {
        public string url { get; set; }
        public int ukuran { get; set; }
        public string formated_size { get; set; }
        public string res { get; set; }
    }
    
    public class video
    {
        public string judul { get; set; }
        public string fname { get; set; }
        public ObservableCollection<Xfile> xfile { get; set; }
    }
    
    public class RootObject
    {
        public bool error { get; set; }
        public int total_data { get; set; }
        public string data_per_page { get; set; }
        public int total_page { get; set; }
        public int current_total { get; set; }
        public string tipe { get; set; }
    
        [JsonProperty("data")]
        public ObservableCollection<video> videos { get; set; }
    }
