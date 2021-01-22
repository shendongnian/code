    class ExpandedRow
    {
        public string Value { get; set; }
        public bool IsExpanded { get; set; }
        private readonly List<ExpandedRow> _subRows = new List<ExpandedRow>();
        public List<ExpandedRow> SubRows { get { return _subRows; } }
    }
