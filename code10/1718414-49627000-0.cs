    class Document
    {
        public Hits hits { set; get; }
    }
    class Hits
    {
        public IEnumerable<Hit> Hits { set; get; }
    }
    class Hit
    {
        public Source _source { set; get; }
    }
    class Source
    {
        public string type { set; get; }
    }
