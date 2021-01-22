    public class RowList : List<Row> {
        public Row this[string key] {
            get { return this.Where( x => x.Name == key ).FirstOrDefault(); }
        }
    }
----------
    public class Tbl
    {
        public RowList Rows { get; set; }
    }
    
    Tbl t = new Tbl();
    // ...
    Row r = t.Rows["Row2"];
