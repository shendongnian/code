    public class GridData
    {
        public GridFilter[] Filters { get; set; }
        public string Logic { get; set; }
    }
    public class GridFilter
    {
        public string Operator { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
    }
