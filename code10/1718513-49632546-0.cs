    public class GridFilter
    {
        public string Operator { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
        public string Logic { get; set; }
        public string Type { get; set; }
        public GridFilter[] Filters { get; set; }
        public GridFilter()
        {
        }
    }
