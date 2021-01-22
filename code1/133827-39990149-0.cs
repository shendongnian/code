     public class GChartsDataTbl
    {
        public List<Col> cols { get; set; }
        public List<Row> rows { get; set; }
    }
    public class Col
    {
        public string id { get; set; }
        public string type { get; set; }
    }
    public class C
    {
        public string v { get; set; }
        public object f { get; set; }
    }
    public class Row
    {
        public List<C> c { get; set; }
    }
