    private struct CellValue
    {
      private List<CellValue> _column;
      private List<CellValue> _row;
      private string text;
      public List<CellValue> column {
         get { return _column; }
         set {
             if(_column!=null) { _column.Remove(this); }
             _column = value;
             _column.Add(this);
            }
      public List<CellValue> row {
         get { return _row; }
         set {
             if(_row!=null) { _row.Remove(this); }
             _row = value;
             _row.Add(this);
            }
    }
    private List<List<CellValue>> MyRows    = new List<List<CellValue>>;
    private List<List<CellValue>> MyColumns = new List<List<CellValue>>;
