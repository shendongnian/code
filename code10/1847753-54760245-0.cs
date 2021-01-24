    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }
    public class Class1
    {
        public string extraction_method { get; set; }
        public float top { get; set; }
        public float left { get; set; }
        public float width { get; set; }
        public float height { get; set; }
        public Datum[][] data { get; set; }
        public int spec_index { get; set; }
    }
    public class Datum
    {
        public float top { get; set; }
        public float left { get; set; }
        public float width { get; set; }
        public float height { get; set; }
        public string text { get; set; }
    }
