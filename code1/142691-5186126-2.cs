    public class Cell
    {
        private List<string> _text = new List<string>();
        public List<string> Text 
        { 
            get { return _text; }
            set { _text = value; }
        }
        public int ColSpan { get; set; }
        public int RowSpan { get; set; }
        
        public Cell(int colSpan, int rowSpan, List<string> text)
        {
            ColSpan = colSpan;
            RowSpan = rowSpan;
            _text = text;
        }
        
        public Cell(int colSpan, int rowSpan)
        {
            ColSpan = colSpan;
            RowSpan = rowSpan;
        }
    }
