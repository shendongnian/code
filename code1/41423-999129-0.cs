    private struct CellValue
    {
      private LinkedList<CellValue> _column;
      private LinkedList<CellValue> _row;
      private string text;
      public LinkedList<CellValue> column {
         get { return _column; }
         set {
             if(_column!=null) { column.Remove(this); }
             _column = value;
             _column.Add(this);
            }
      public LinkedList<CellValue> row {
         get { return _row; }
         set {
             if(_column!=null) { row.Remove(this); }
             _row = value;
             _row.Add(this);
            }
    }
    private LinkedList<CellValue> MyRows = new LinkedList<CellValue>;
    private LinkedList<CellValue> MyColumns = new LinkedList<CellValue>;
