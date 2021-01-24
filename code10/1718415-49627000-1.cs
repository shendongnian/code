    class Document
    {
        public Hits hits { set; get; }
    }
    class Hits
    {
        public IEnumerable<Hit> hits { set; get; }
    }
    class Hit
    {
        public Source _source { set; get; }
    }
    class Source
    {
        public string type { set; get; }
    }
