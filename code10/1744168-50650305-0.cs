    public class FeaturedListing
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Published { get; set; }
        public int Views { get; set; }
        public string ViewsStr { get { return string.Format("{0} visits", Views); } }
        public string Featured { get; set; }
        public string CategoryName { get; set; }
    }
