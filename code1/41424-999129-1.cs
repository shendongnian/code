    private struct CellValue
    {
      private List<CellValue> _column;
      private List<CellValue> _row;
      private string text;
      public List<CellValue> column {
         get { return _column; }
         set {
             if(_column!=null) { column.Remove(this); }
             _column = value;
             _column.Add(this);
            }
      public List<CellValue> row {
         get { return _row; }
         set {
             if(_column!=null) { row.Remove(this); }
             _row = value;
             _row.Add(this);
            }
    }
    private LinkedList<List<CellValue>> MyRows    = new LinkedList<List<CellValue>>;
    private LinkedList<List<CellValue>> MyColumns = new LinkedList<List<CellValue>>;
